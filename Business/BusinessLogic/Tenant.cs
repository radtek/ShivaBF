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
using SHF.ViewModel;

namespace SHF.Business.BusinessLogic
{
    public class Tenant : BaseBusiness, ITenant
    {

        public ViewModel.BusinessResultViewModel<ViewModel.TenantIndexViewModel> Index(HttpRequestBase Request)
        {
            List<ViewModel.TenantIndexViewModel> collection;
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
                totalRecords = unitOfWork.TenantRepository.Get()
                    .Join(unitOfWork.AspNetUserRepository.Get(), tenant => tenant.ID, aspNetUser => aspNetUser.Tenant_ID, (tenant, aspNetUser) => new { tenant, aspNetUser })
                    .Join(unitOfWork.AspNetUserRoleRepository.Get(), tenant_aspNetUser => tenant_aspNetUser.aspNetUser.ID, aspNetUserRole => aspNetUserRole.AspNetUser_ID, (tenant_aspNetUser, aspNetUserRole) => new { tenant_aspNetUser, aspNetUserRole })
                    .Join(unitOfWork.AspNetRoleRepository.Get(), tenant_aspNetUser_aspNetUserRole => tenant_aspNetUser_aspNetUserRole.aspNetUserRole.AspNetRole_ID, aspNetRole => aspNetRole.ID, (tenant_aspNetUser_aspNetUserRole, aspNetRole) => new { tenant_aspNetUser_aspNetUserRole, aspNetRole })
                    .Join(unitOfWork.CodeValueRepository.Get(), tenant_aspNetUser_aspNetUserRole_Billing_Country => new { Id = tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.BillingAddressCountry_ID, Value = tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.BillingAddressCountryValue }, country => new { Id = country.Code_ID, Value = country.Value }, (tenant_aspNetUser_aspNetUserRole_Billing_Country, country) => new { tenant_aspNetUser_aspNetUserRole_Billing_Country, country })
                    .Join(unitOfWork.CodeValueRepository.Get(), tenant_aspNetUser_aspNetUserRole_Billing_Country_State => new { Id = tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.BillingAddressState_ID, Value = tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.BillingAddressStateValue }, state => new { Id = state.Code_ID, Value = state.Value }, (tenant_aspNetUser_aspNetUserRole_Billing_Country_State, state) => new { tenant_aspNetUser_aspNetUserRole_Billing_Country_State, state })
                    .Join(unitOfWork.CodeValueRepository.Get(), tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict => new { Id = tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.BillingAddressCityOrDistrict_ID, Value = tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.BillingAddressCityOrDistrictValue }, cityOrDistrict => new { Id = cityOrDistrict.Code_ID, Value = cityOrDistrict.Value }, (tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict, cityOrDistrict) => new { tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict, cityOrDistrict })
                    .Join(unitOfWork.CodeValueRepository.Get(), tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country => new { Id = tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.BillingAddressCountry_ID, Value = tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.ShippingAddressCountryValue }, country => new { Id = country.Code_ID, Value = country.Value }, (tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country, country) => new { tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country, country })
                    .Join(unitOfWork.CodeValueRepository.Get(), tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State => new { Id = tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.ShippingAddressState_ID, Value = tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.ShippingAddressStateValue }, state => new { Id = state.Code_ID, Value = state.Value }, (tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State, state) => new { tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State, state })
                    .Join(unitOfWork.CodeValueRepository.Get(), tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict => new { Id = tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.ShippingAddressCityOrDistrict_ID, Value = tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.ShippingAddressCityOrDistrictValue }, cityOrDistrict => new { Id = cityOrDistrict.Code_ID, Value = cityOrDistrict.Value }, (tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict, cityOrDistrict) => new { tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict, cityOrDistrict })
                    .Count(x => x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.aspNetRole.DisplayName == busConstant.Settings.AspNetRoles.ADMIN
                      && (x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.ID.ToString().Contains(searchValue)
                         || x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.Name.Contains(searchValue)
                         || x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.country.Description.Contains(searchValue)
                          || x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.state.Description.Contains(searchValue)
                           || x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.cityOrDistrict.Description.Contains(searchValue)
                           || x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.country.Description.Contains(searchValue)
                          || x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.state.Description.Contains(searchValue)
                         || x.cityOrDistrict.Description.Contains(searchValue)
                         || x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.ContactPerson.Contains(searchValue)
                         || x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.ContactNumber.Contains(searchValue)
                         || x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.Email.Contains(searchValue)
                         || x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.GST.Contains(searchValue)
                         || x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.NoOfSHFItems.ToString().Contains(searchValue)
                         || x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.NoOfLocations.ToString().Contains(searchValue)
                         || x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.CreatedBy.Contains(searchValue)
                         || x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.UpdatedBy.Contains(searchValue)
                         || x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                         || x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.TenantRepository.Get(includeProperties: "BillingAddressCountry,BillingAddressState,BillingAddressCityOrDistrict,ShippingAddressCountry,ShippingAddressState,ShippingAddressCityOrDistrict")
                    .Join(unitOfWork.AspNetUserRepository.Get(), tenant => tenant.ID, aspNetUser => aspNetUser.Tenant_ID, (tenant, aspNetUser) => new { tenant, aspNetUser })
                    .Join(unitOfWork.AspNetUserRoleRepository.Get(), tenant_aspNetUser => tenant_aspNetUser.aspNetUser.ID, aspNetUserRole => aspNetUserRole.AspNetUser_ID, (tenant_aspNetUser, aspNetUserRole) => new { tenant_aspNetUser, aspNetUserRole })
                    .Join(unitOfWork.AspNetRoleRepository.Get(), tenant_aspNetUser_aspNetUserRole => tenant_aspNetUser_aspNetUserRole.aspNetUserRole.AspNetRole_ID, aspNetRole => aspNetRole.ID, (tenant_aspNetUser_aspNetUserRole, aspNetRole) => new { tenant_aspNetUser_aspNetUserRole, aspNetRole })
                    .Join(unitOfWork.CodeValueRepository.Get(), tenant_aspNetUser_aspNetUserRole_Billing_Country => new { Id = tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.BillingAddressCountry_ID, Value = tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.BillingAddressCountryValue }, country => new { Id = country.Code_ID, Value = country.Value }, (tenant_aspNetUser_aspNetUserRole_Billing_Country, country) => new { tenant_aspNetUser_aspNetUserRole_Billing_Country, country })
                    .Join(unitOfWork.CodeValueRepository.Get(), tenant_aspNetUser_aspNetUserRole_Billing_Country_State => new { Id = tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.BillingAddressState_ID, Value = tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.BillingAddressStateValue }, state => new { Id = state.Code_ID, Value = state.Value }, (tenant_aspNetUser_aspNetUserRole_Billing_Country_State, state) => new { tenant_aspNetUser_aspNetUserRole_Billing_Country_State, state })
                    .Join(unitOfWork.CodeValueRepository.Get(), tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict => new { Id = tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.BillingAddressCityOrDistrict_ID, Value = tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.BillingAddressCityOrDistrictValue }, cityOrDistrict => new { Id = cityOrDistrict.Code_ID, Value = cityOrDistrict.Value }, (tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict, cityOrDistrict) => new { tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict, cityOrDistrict })
                    .Join(unitOfWork.CodeValueRepository.Get(), tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country => new { Id = tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.BillingAddressCountry_ID, Value = tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.ShippingAddressCountryValue }, country => new { Id = country.Code_ID, Value = country.Value }, (tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country, country) => new { tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country, country })
                    .Join(unitOfWork.CodeValueRepository.Get(), tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State => new { Id = tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.ShippingAddressState_ID, Value = tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.ShippingAddressStateValue }, state => new { Id = state.Code_ID, Value = state.Value }, (tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State, state) => new { tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State, state })
                    .Join(unitOfWork.CodeValueRepository.Get(), tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict => new { Id = tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.ShippingAddressCityOrDistrict_ID, Value = tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.ShippingAddressCityOrDistrictValue }, cityOrDistrict => new { Id = cityOrDistrict.Code_ID, Value = cityOrDistrict.Value }, (tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict, cityOrDistrict) => new { tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict, cityOrDistrict })
                    .Where(x => x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.aspNetRole.DisplayName == busConstant.Settings.AspNetRoles.ADMIN
                      && (x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.ID.ToString().Contains(searchValue)
                         || x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.Name.Contains(searchValue)
                         || x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.country.Description.Contains(searchValue)
                          || x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.state.Description.Contains(searchValue)
                           || x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.cityOrDistrict.Description.Contains(searchValue)
                           || x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.country.Description.Contains(searchValue)
                          || x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.state.Description.Contains(searchValue)
                         || x.cityOrDistrict.Description.Contains(searchValue)
                         || x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.ContactPerson.Contains(searchValue)
                         || x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.ContactNumber.Contains(searchValue)
                         || x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.Email.Contains(searchValue)
                         || x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.GST.Contains(searchValue)
                         || x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.NoOfSHFItems.ToString().Contains(searchValue)
                         || x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.NoOfLocations.ToString().Contains(searchValue)
                         || x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.CreatedBy.Contains(searchValue)
                         || x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.UpdatedBy.Contains(searchValue)
                         || x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                         || x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)))
                    .OrderBy(sortColumn + " " + sortColumnDir).Skip(skip).Take(pageSize).ToList().Select(x => new ViewModel.TenantIndexViewModel
                    {
                        ID = x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.ID,
                        Name = x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.Name,
                        //BillingAddress = x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.BillingAddressStreet1 +","+ x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.BillingAddressStreet2+","+ x.cityOrDistrict.Description+","+x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.state.Description + "," + x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.country.Description,
                        BillingAddress = x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.BillingAddress,
                        //ShippingAddress = x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.BillingAddressStreet1 + "," + x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.BillingAddressStreet2 + "," + x.cityOrDistrict.Description + "," + x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.state.Description + "," + x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.country.Description,
                        ShippingAddress = x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.ShippingAddress,
                        ContactNumber = x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.ContactNumber,
                        ContactPerson = x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.ContactPerson,
                        Email = x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.Email,
                        GST = x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.GST,
                        NoOfSHFItems = x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.NoOfSHFItems,
                        NoOfLocations = x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.NoOfLocations,
                        Username = x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.aspNetUser.UserName,
                        CreatedBy = x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.CreatedBy,
                        CreatedOn = x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.CreatedOn,
                        UpdatedBy = x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.UpdatedBy,
                        UpdatedOn = x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.UpdatedOn,
                        IsDeleted = x.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.IsDeleted
                    }).ToList();

                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.TenantIndexViewModel>
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


        public EntityModel.Tenant Create(EntityModel.Tenant entity)
        {
            try
            {
                return unitOfWork.TenantRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public async Task<EntityModel.Tenant> CreateAsync(EntityModel.Tenant entity)
        {
            try
            {
                return await unitOfWork.TenantRepository.InsertAsync(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }



        public EntityModel.Tenant GetById(long Id)
        {
            try
            {
                EntityModel.Tenant entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.TenantRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<EntityModel.Tenant> GetByIdAsyc(long Id)
        {
            try
            {
                EntityModel.Tenant entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = await unitOfWork.TenantRepository.GetByIDAsync(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public EntityModel.Tenant Update(EntityModel.Tenant entity)
        {
            try
            {
                return unitOfWork.TenantRepository.Update(entity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<EntityModel.Tenant> UpdateAsync(EntityModel.Tenant entity)
        {
            try
            {
                return await unitOfWork.TenantRepository.UpdateAsync(entity);
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
                unitOfWork.TenantRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task DeleteAsync(long Id)
        {
            try
            {
                await unitOfWork.TenantRepository.DeleteAsync(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.Tenant> GetAll()
        {
            try
            {
                return unitOfWork.TenantRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IEnumerable<EntityModel.Tenant>> GetAllAsync()
        {
            try
            {
                return await unitOfWork.TenantRepository.GetAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.Tenant> FindBy(Expression<Func<EntityModel.Tenant, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.Tenant> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.TenantRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.TenantRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<EntityModel.Tenant>> FindByAsyc(Expression<Func<EntityModel.Tenant, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.Tenant> entities;
                if (filter.IsNotNull())
                {
                    entities = await unitOfWork.TenantRepository.GetAsync(filter);
                }
                else
                {
                    entities = await unitOfWork.TenantRepository.GetAsync();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void DeleteWhere(Expression<Func<EntityModel.Tenant, bool>> filter = null)
        {
            try
            {
                unitOfWork.TenantRepository.DeleteWhere(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task DeleteWhereAsync(Expression<Func<EntityModel.Tenant, bool>> filter = null)
        {
            try
            {
                await unitOfWork.TenantRepository.DeleteWhereAsync(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<TenantDropdownListViewModel> GetDropdownList()
        {
            try
            {
                var TenantDropdownListViewModel = unitOfWork.TenantRepository.Get().Select(x => new ViewModel.TenantDropdownListViewModel
                {
                    ID = x.ID,
                    Name = x.Name
                });

                return TenantDropdownListViewModel;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



    }
}
