using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Web;
using Dapper;
using SHF.Business.Interface;
using SHF.EntityModel;
using SHF.Helper;


namespace SHF.Business.BusinessLogic
{
    public class IPInfo : BaseBusiness, IIPInfo
    {
        public ViewModel.BusinessResultViewModel<ViewModel.IPInfoIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.IPInfoIndexViewModel> collection;
            // ArrayList arrayList;
            try
            {
                //Datatable parameter
                var draw = Request.Form.GetValues("draw").FirstOrDefault();
                //paging parameter
                var start = Request.Form.GetValues("start").FirstOrDefault();
                var length = Request.Form.GetValues("length").FirstOrDefault();
                //sorting parameter            
                var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
                var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();

                //Global filter parameter
                var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();

                int pageSize = length != null ? Convert.ToInt32(length) : busConstant.Numbers.Integer.ZERO;
                int skip = start != null ? Convert.ToInt32(start) : busConstant.Numbers.Integer.ZERO;
                int totalRecords = busConstant.Numbers.Integer.ZERO;


                //Count total Records meeting criteria
                totalRecords = unitOfWork.IPInfoRepository.Get().Join(unitOfWork.TenantRepository.Get(), IPInfo => IPInfo.Tenant_ID, tenant => tenant.ID, (IPInfo, tenant) => new { IPInfo, tenant })
                    .Join(unitOfWork.AsnsRepository.Get(), IPInfo_tenant => IPInfo_tenant.IPInfo.Asn_ID, Asns => Asns.ID, (IPInfo_tenant, Asns) => new { IPInfo_tenant, Asns })
                    .Join(unitOfWork.CarriersRepository.Get(), IPInfo_tenant_Asns => IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.Carrier_ID, Carriers => Carriers.ID, (IPInfo_tenant_Asns, Carriers) => new { IPInfo_tenant_Asns, Carriers })
                    .Join(unitOfWork.LanguagesRepository.Get(), IPInfo_tenant_Asns_Carriers => IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.Language_ID, Language => Language.ID, (IPInfo_tenant_Asns_Carriers, Language) => new { IPInfo_tenant_Asns_Carriers, Language })
                    .Join(unitOfWork.CurrenciesRepository.Get(), IPInfo_tenant_Asns_Carriers_Language => IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.Currency_ID, Currencies => Currencies.ID, (IPInfo_tenant_Asns_Carriers_Language, Currencies) => new { IPInfo_tenant_Asns_Carriers_Language, Currencies })
                    .Join(unitOfWork.TimeZonesRepository.Get(), IPInfo_tenant_Asns_Carriers_Language_Currencies => IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.TimeZone_ID, TimeZone => TimeZone.ID, (IPInfo_tenant_Asns_Carriers_Language_Currencies, TimeZone) => new { IPInfo_tenant_Asns_Carriers_Language_Currencies, TimeZone })
                    .Join(unitOfWork.ThreatsRepository.Get(), IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone => IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.Threat_ID, Threat => Threat.ID, (IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone, Threat) => new { IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone, Threat })
                    .Count(x => (tenant_Id == null || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.Tenant_ID == tenant_Id)
                            && (x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.ID.ToString().Contains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.ip.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.is_eu.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.city.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.region.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.region_code.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.country_name.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.country_code.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.continent_name.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.continent_code.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.latitude.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.longitude.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.postal.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.calling_code.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.flag.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.emoji_flag.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.emoji_unicode.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.Asns.asn.CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.Asns.name.CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.Asns.domain.CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.Asns.route.CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.Asns.type.CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.Carriers.name.CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.Carriers.mcc.CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.Carriers.mnc.CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.Language.name.CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.Language.native.CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.Currencies.name.CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.Currencies.code.CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.Currencies.symbol.CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.Currencies.native.CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.Currencies.plural.CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.TimeZone.name.CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.TimeZone.abbr.CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.TimeZone.offset.CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.TimeZone.is_dst.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.TimeZone.current_time.ToString().CaseInsensitiveContains(searchValue)
                        || x.Threat.is_tor.ToString().CaseInsensitiveContains(searchValue)
                        || x.Threat.is_proxy.ToString().CaseInsensitiveContains(searchValue)
                        || x.Threat.is_anonymous.ToString().CaseInsensitiveContains(searchValue)
                        || x.Threat.is_known_attacker.ToString().CaseInsensitiveContains(searchValue)
                        || x.Threat.is_known_abuser.ToString().CaseInsensitiveContains(searchValue)
                        || x.Threat.is_threat.ToString().CaseInsensitiveContains(searchValue)
                        || x.Threat.is_bogon.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.IPInfoRepository.Get().Join(unitOfWork.TenantRepository.Get(), IPInfo => IPInfo.Tenant_ID, tenant => tenant.ID, (IPInfo, tenant) => new { IPInfo, tenant })
                    .Join(unitOfWork.AsnsRepository.Get(), IPInfo_tenant => IPInfo_tenant.IPInfo.Asn_ID, Asns => Asns.ID, (IPInfo_tenant, Asns) => new { IPInfo_tenant, Asns })
                    .Join(unitOfWork.CarriersRepository.Get(), IPInfo_tenant_Asns => IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.Carrier_ID, Carriers => Carriers.ID, (IPInfo_tenant_Asns, Carriers) => new { IPInfo_tenant_Asns, Carriers })
                    .Join(unitOfWork.LanguagesRepository.Get(), IPInfo_tenant_Asns_Carriers => IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.Language_ID, Language => Language.ID, (IPInfo_tenant_Asns_Carriers, Language) => new { IPInfo_tenant_Asns_Carriers, Language })
                    .Join(unitOfWork.CurrenciesRepository.Get(), IPInfo_tenant_Asns_Carriers_Language => IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.Currency_ID, Currencies => Currencies.ID, (IPInfo_tenant_Asns_Carriers_Language, Currencies) => new { IPInfo_tenant_Asns_Carriers_Language, Currencies })
                    .Join(unitOfWork.TimeZonesRepository.Get(), IPInfo_tenant_Asns_Carriers_Language_Currencies => IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.TimeZone_ID, TimeZone => TimeZone.ID, (IPInfo_tenant_Asns_Carriers_Language_Currencies, TimeZone) => new { IPInfo_tenant_Asns_Carriers_Language_Currencies, TimeZone })
                    .Join(unitOfWork.ThreatsRepository.Get(), IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone => IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.Threat_ID, Threat => Threat.ID, (IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone, Threat) => new { IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone, Threat })
                    .Where(x => (tenant_Id == null || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.Tenant_ID == tenant_Id)
                            && (x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.ID.ToString().Contains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.ip.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.is_eu.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.city.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.region.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.region_code.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.country_name.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.country_code.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.continent_name.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.continent_code.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.latitude.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.longitude.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.postal.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.calling_code.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.flag.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.emoji_flag.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.emoji_unicode.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.Asns.asn.CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.Asns.name.CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.Asns.domain.CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.Asns.route.CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.Asns.type.CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.Carriers.name.CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.Carriers.mcc.CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.Carriers.mnc.CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.Language.name.CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.Language.native.CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.Currencies.name.CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.Currencies.code.CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.Currencies.symbol.CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.Currencies.native.CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.Currencies.plural.CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.TimeZone.name.CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.TimeZone.abbr.CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.TimeZone.offset.CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.TimeZone.is_dst.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.TimeZone.current_time.ToString().CaseInsensitiveContains(searchValue)
                        || x.Threat.is_tor.ToString().CaseInsensitiveContains(searchValue)
                        || x.Threat.is_proxy.ToString().CaseInsensitiveContains(searchValue)
                        || x.Threat.is_anonymous.ToString().CaseInsensitiveContains(searchValue)
                        || x.Threat.is_known_attacker.ToString().CaseInsensitiveContains(searchValue)
                        || x.Threat.is_known_abuser.ToString().CaseInsensitiveContains(searchValue)
                        || x.Threat.is_threat.ToString().CaseInsensitiveContains(searchValue)
                        || x.Threat.is_bogon.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.IPInfoIndexViewModel
                    {
                        ip = x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.ip.ToString(),
                        is_eu = x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.is_eu,
                        city = x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.city,
                        region = x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.region,
                        region_code = x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.region_code,
                        country_name = x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.country_name,
                        country_code = x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.country_code,
                        continent_name = x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.continent_name,
                        continent_code = x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.continent_code,
                        latitude = x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.latitude,
                        longitude = x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.longitude,
                        postal = x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.postal,
                        calling_code = x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.calling_code,
                        flag = x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.flag,
                        emoji_flag = x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.emoji_flag,
                        emoji_unicode = x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.emoji_unicode,
                        Asn_asn = x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.Asns.asn,
                        Asn_name = x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.Asns.name,
                        Asn_domain = x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.Asns.domain,
                        Asn_route = x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.Asns.route,
                        Asn_type = x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.Asns.type,
                        Carrier_name = x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.Carriers.name,
                        Carrier_mcc = x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.Carriers.mcc,
                        Carrier_mnc = x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.Carriers.mnc,
                        Language_name = x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.Language.name,
                        Language_native = x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.Language.native,
                        Currency_name = x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.Currencies.name,
                        Currency_code = x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.Currencies.code,
                        Currency_symbol = x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.Currencies.symbol,
                        Currency_native = x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.Currencies.native,
                        Currency_plural = x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.Currencies.plural,
                        TimeZone_name = x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.TimeZone.name,
                        TimeZone_abbr = x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.TimeZone.abbr,
                        TimeZone_offset = x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.TimeZone.offset,
                        TimeZone_is_dst = x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.TimeZone.is_dst,
                        TimeZone_current_time = x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.TimeZone.current_time,
                        Threat_is_tor = x.Threat.is_tor,
                        Threat_is_proxy = x.Threat.is_proxy,
                        Threat_is_anonymous = x.Threat.is_anonymous,
                        Threat_is_known_attacker = x.Threat.is_known_attacker,
                        Threat_is_known_abuser = x.Threat.is_known_abuser,
                        Threat_is_threat = x.Threat.is_threat,
                        Threat_is_bogon = x.Threat.is_bogon,
                        TenantName = x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.tenant.Name,
                        Tenant_ID = x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.tenant.ID,
                        CreatedBy = x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.CreatedBy,
                        CreatedOn = x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.CreatedOn,
                        UpdatedBy = x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.UpdatedBy,
                        UpdatedOn = x.IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.UpdatedOn
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.IPInfoIndexViewModel>
                {
                    Draw = draw,
                    RecordsFiltered = totalRecords,
                    RecordsTotal = totalRecords,
                    Data = collection
                };

                return businessResultViewModel;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                collection = null;
            }
        }





        public EntityModel.IPInfo Create(EntityModel.IPInfo entity)
        {
            try
            {
                return unitOfWork.IPInfoRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.IPInfo GetById(long Id)
        {
            try
            {
                EntityModel.IPInfo entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.IPInfoRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.IPInfo Update(EntityModel.IPInfo entity)
        {
            try
            {
                return unitOfWork.IPInfoRepository.Update(entity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void Delete(long Id)
        {
            try
            {
                unitOfWork.IPInfoRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.IPInfo> GetAll()
        {
            try
            {
                return unitOfWork.IPInfoRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.IPInfo> FindBy(Expression<Func<EntityModel.IPInfo, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.IPInfo> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.IPInfoRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.IPInfoRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.IPInfo, bool>> filter = null)
        {
            try
            {
                unitOfWork.IPInfoRepository.DeleteWhere(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        //public IEnumerable<ProductDropdownListViewModel> GetDropdownList()
        //{
        //    try
        //    {
        //        var productDropdownListViewModel = unitOfWork.ProductRepository.Get().Select(x => new ViewModel.ProductDropdownListViewModel
        //        {
        //            ID = x.ID,
        //            Name = x.Name
        //        });

        //        return productDropdownListViewModel;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        public Int32 Count(Expression<Func<EntityModel.IPInfo, bool>> filter = null)
        {
            try
            {
                return unitOfWork.IPInfoRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
