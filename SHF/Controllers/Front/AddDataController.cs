using System;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Transactions;
using AutoMapper;
using AutoMapper.EntityFramework;
using AutoMapper.Collection;
using AutoMapper.Collection.LinqToSQL;
using SHF.Helper;
using SHF.Web.Filters;
using SHF.Models;
using SHF.ViewModel;
using System.Reflection;
using System.ComponentModel;


namespace SHF.Controllers.Front
{
    [AllowAnonymous]
    public class AddDataController : BaseController
    {
        #region [Field & Contructor]

        private Business.Interface.ICommentsReply businessCommentsReply;
        private Business.Interface.IBlogCommentsDetails businessBlogCommentsDetails;
        private Business.Interface.IBlogMaster businessBlogMaster;
        private Business.Interface.IAsn businessAsn;
        private Business.Interface.ICarrier businessCarrier;
        private Business.Interface.ICurrency businessCurrency;
        private Business.Interface.ILanguage businessLanguage;
        private Business.Interface.ITimeZone businessTimeZone;
        private Business.Interface.IThreat businessThreat;
        private Business.Interface.IIPInfo businessIPInfo;


        public AddDataController(Business.Interface.IBlogCommentsDetails IBlogCommentsDetails, Business.Interface.IBlogMaster IBlogMaster, Business.Interface.ICommentsReply ICommentsReply, Business.Interface.IAsn IAsn, Business.Interface.ICarrier ICarrier
            , Business.Interface.ICurrency ICurrency, Business.Interface.ILanguage ILanguage, Business.Interface.ITimeZone ITimeZone, Business.Interface.IThreat IThreat, Business.Interface.IIPInfo IIPInfo)
        {
            this.businessCommentsReply = ICommentsReply;
            this.businessBlogCommentsDetails = IBlogCommentsDetails;
            this.businessBlogMaster = IBlogMaster;
            this.businessAsn = IAsn;
            this.businessCarrier = ICarrier;
            this.businessCurrency = ICurrency;
            this.businessLanguage = ILanguage;
            this.businessTimeZone = ITimeZone;
            this.businessThreat = IThreat;
            this.businessIPInfo = IIPInfo;
        }

        #endregion

        #region [ActionMethod]

        [HttpPost]
        [Route("Post/AddData/BlogCommentsDetails/CreateAsync")]
        public async Task<ActionResult> CreateAsync(ViewModel.BlogCommentsDetailsCreateOrEditViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return ValidationResponse();
                }
                else
                {
                    using (var transaction = new TransactionScope())
                    {
                        try
                        {
                            var productId = businessBlogCommentsDetails.FindBy(Services1Section4 => Services1Section4.Tenant_ID == model.Tenant_ID && Services1Section4.ID == model.ID).FirstOrDefault();

                            if (productId.IsNotNull())
                            {
                                transaction.Complete();
                                var response = new JsonResponse<dynamic>()
                                {
                                    Type = busConstant.Messages.Type.EXCEPTION,
                                    Title = busConstant.Messages.Title.ERROR,
                                    Icon = busConstant.Messages.Icon.ERROR,
                                    MessageCode = busConstant.Messages.MessageCode.SKU_ALREADY_EXIST,
                                    Message = busConstant.Messages.Type.Responses.ALREADY_EXIST
                                };
                                return Json(response, JsonRequestBehavior.AllowGet);
                            }
                            else
                            {

                                var entity = new EntityModel.BlogCommentsDetails();
                                entity.Tenant = null;
                                entity.BlogMaster = null;
                                entity.Name = model.Name;
                                entity.EmailId = model.EmailId;
                                entity.Comment = model.Comment;
                                entity.Blog_Id = model.Blog_Id;
                                entity.IsActive = model.IsActive;
                                entity.IsAdminApproved = false;
                                entity.Tenant_ID = model.Tenant_ID;
                                this.businessBlogCommentsDetails.Create(entity);
                                transaction.Complete();

                                var response = new JsonResponse<dynamic>()
                                {
                                    Type = busConstant.Messages.Type.RESPONSE,
                                    Title = busConstant.Messages.Title.SUCCESS,
                                    Icon = busConstant.Messages.Icon.SUCCESS,
                                    MessageCode = busConstant.Messages.MessageCode.SAVE,
                                    Message = busConstant.Messages.Type.Responses.SAVE
                                };

                                return Json(response, JsonRequestBehavior.AllowGet);
                            }
                        }
                        catch (Exception ex)
                        {
                            transaction.Dispose();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return ExceptionResponse(ex);
            }
            finally
            {
                // unitOfWork.Dispose();
            }
        }

        [HttpPost]
        [Route("Post/AddData/CommentsReply/CreateAsync")]
        public async Task<ActionResult> CreateAsync(ViewModel.CommentsReplyCreateOrEditViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return ValidationResponse();
                }
                else
                {
                    using (var transaction = new TransactionScope())
                    {
                        try
                        {
                            var productId = businessCommentsReply.FindBy(Services1Section4 => Services1Section4.Tenant_ID == model.Tenant_ID && Services1Section4.ID == model.ID).FirstOrDefault();

                            if (productId.IsNotNull())
                            {
                                transaction.Complete();
                                var response = new JsonResponse<dynamic>()
                                {
                                    Type = busConstant.Messages.Type.EXCEPTION,
                                    Title = busConstant.Messages.Title.ERROR,
                                    Icon = busConstant.Messages.Icon.ERROR,
                                    MessageCode = busConstant.Messages.MessageCode.SKU_ALREADY_EXIST,
                                    Message = busConstant.Messages.Type.Responses.ALREADY_EXIST
                                };
                                return Json(response, JsonRequestBehavior.AllowGet);
                            }
                            else
                            {

                                var entity = new EntityModel.CommentsReply();
                                entity.Tenant = null;
                                entity.BlogMaster = null;
                                entity.BlogCommentsDetails = null;
                                entity.Blog_Id = model.Blog_Id;
                                entity.BCD_Id = model.BCD_Id;
                                entity.Name = model.Name;
                                entity.EmailId = model.EmailId;
                                entity.Comment = model.Comment;
                                entity.Blog_Id = model.Blog_Id;
                                entity.IsActive = model.IsActive;
                                entity.IsAdminApproved = false;
                                entity.Tenant_ID = model.Tenant_ID;
                                this.businessCommentsReply.Create(entity);
                                transaction.Complete();

                                var response = new JsonResponse<dynamic>()
                                {
                                    Type = busConstant.Messages.Type.RESPONSE,
                                    Title = busConstant.Messages.Title.SUCCESS,
                                    Icon = busConstant.Messages.Icon.SUCCESS,
                                    MessageCode = busConstant.Messages.MessageCode.SAVE,
                                    Message = busConstant.Messages.Type.Responses.SAVE
                                };

                                return Json(response, JsonRequestBehavior.AllowGet);
                            }
                        }
                        catch (Exception ex)
                        {
                            transaction.Dispose();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return ExceptionResponse(ex);
            }
            finally
            {
                // unitOfWork.Dispose();
            }
        }

        [HttpPost]
        [Route("Post/AddData/IPInfo/AddIPInfo")]
        public async Task<ActionResult> AddIPInfo(ViewModel.IPInfoCreateOrEditViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return ValidationResponse();
                }
                else
                {
                    using (var transaction = new TransactionScope())
                    {
                        try
                        {
                            var asnId = businessAsn.FindBy(asn => asn.Tenant_ID == model.Tenant_ID && asn.asn == model.Asn.asn && asn.domain == model.Asn.domain
                            && asn.route == model.Asn.route && asn.type == model.Asn.type).FirstOrDefault();

                            if (asnId.IsNull() && model.Asn.IsNotNull())
                            {
                                var entity = new EntityModel.Asn();
                                entity.Tenant = null;
                                entity.name = model.Asn.name;
                                entity.asn = model.Asn.asn;
                                entity.domain = model.Asn.domain;
                                entity.route = model.Asn.route;
                                entity.type = model.Asn.type;
                                entity.Tenant_ID = model.Tenant_ID;
                                this.businessAsn.Create(entity);

                                asnId = entity;
                            }

                            var CarrierId = businessCarrier.FindBy(Carrier => Carrier.Tenant_ID == model.Tenant_ID && Carrier.mcc == model.carrier.mcc && Carrier.mnc == model.carrier.mnc
                            && Carrier.name == model.carrier.name).FirstOrDefault();

                            if (CarrierId.IsNull() && model.carrier.IsNotNull())
                            {
                                var entity = new EntityModel.Carrier();
                                entity.Tenant = null;
                                entity.name = model.carrier.name;
                                entity.mcc = model.carrier.mcc;
                                entity.mnc = model.carrier.mnc;
                                entity.Tenant_ID = model.Tenant_ID;
                                this.businessCarrier.Create(entity);

                                CarrierId = entity;
                            }

                            var CurrencyId = businessCurrency.FindBy(Currency => Currency.Tenant_ID == model.Tenant_ID && Currency.code == model.currency.code && Currency.name == model.currency.name
                            && Currency.native == model.currency.native && Currency.plural == model.currency.plural && Currency.symbol == model.currency.symbol).FirstOrDefault();

                            if (CurrencyId.IsNull() && model.currency.IsNotNull())
                            {
                                var entity = new EntityModel.Currency();
                                entity.Tenant = null;
                                entity.name = model.currency.name;
                                entity.code = model.currency.code;
                                entity.symbol = model.currency.symbol;
                                entity.native = model.currency.native;
                                entity.plural = model.currency.plural;
                                entity.Tenant_ID = model.Tenant_ID;
                                this.businessCurrency.Create(entity);
                                CurrencyId = entity;
                            }
                            var language = model.languages.FirstOrDefault();
                            var LanguageId = businessLanguage.FindBy(Language => Language.Tenant_ID == model.Tenant_ID && Language.name == language.name && Language.native == language.native).FirstOrDefault();

                            if (LanguageId.IsNull() && language.IsNotNull())
                            {
                                var entity = new EntityModel.Language();
                                entity.Tenant = null;
                                entity.name = language.name;
                                entity.native = language.native;
                                entity.Tenant_ID = model.Tenant_ID;
                                this.businessLanguage.Create(entity);
                                LanguageId = entity;
                            }

                            var TimeZoneId = businessTimeZone.FindBy(TimeZone => TimeZone.Tenant_ID == model.Tenant_ID && TimeZone.name == model.time_zone.name && TimeZone.abbr == model.time_zone.abbr
                            && TimeZone.offset == model.time_zone.offset && TimeZone.is_dst == model.time_zone.is_dst && TimeZone.current_time == model.time_zone.current_time).FirstOrDefault();

                            if (TimeZoneId.IsNull() && model.time_zone.IsNotNull())
                            {
                                var entity = new EntityModel.TimeZone();
                                entity.Tenant = null;
                                entity.name = model.time_zone.name;
                                entity.abbr = model.time_zone.abbr;
                                entity.offset = model.time_zone.offset;
                                entity.is_dst = model.time_zone.is_dst;
                                entity.current_time = model.time_zone.current_time;
                                entity.Tenant_ID = model.Tenant_ID;
                                this.businessTimeZone.Create(entity);
                                TimeZoneId = entity;
                            }
                            var ThreatId = businessThreat.FindBy(Threat => Threat.Tenant_ID == model.Tenant_ID && Threat.is_tor == model.threat.is_tor && Threat.is_proxy == model.threat.is_proxy
                           && Threat.is_anonymous == model.threat.is_anonymous && Threat.is_known_attacker == model.threat.is_known_attacker && Threat.is_known_abuser == model.threat.is_known_abuser
                           && Threat.is_threat == model.threat.is_threat && Threat.is_bogon == model.threat.is_bogon).FirstOrDefault();

                            if (ThreatId.IsNull() && model.threat.IsNotNull())
                            {
                                var entity = new EntityModel.Threat();
                                entity.Tenant = null;
                                entity.is_tor = model.threat.is_tor;
                                entity.is_proxy = model.threat.is_proxy;
                                entity.is_anonymous = model.threat.is_anonymous;
                                entity.is_known_attacker = model.threat.is_known_attacker;
                                entity.is_known_abuser = model.threat.is_known_abuser;
                                entity.is_threat = model.threat.is_threat;
                                entity.is_bogon = model.threat.is_bogon;
                                entity.Tenant_ID = model.Tenant_ID;
                                this.businessThreat.Create(entity);
                                ThreatId = entity;
                            }

                            var entityIP = new EntityModel.IPInfo();
                            entityIP.ip = model.ip;
                            entityIP.is_eu = model.is_eu;
                            entityIP.city = model.city;
                            entityIP.region = model.region;
                            entityIP.region_code = model.region_code;
                            entityIP.country_name = model.country_name;
                            entityIP.country_code = model.country_code;
                            entityIP.continent_name = model.continent_name;
                            entityIP.continent_code = model.continent_code;
                            entityIP.latitude = model.latitude;
                            entityIP.longitude = model.longitude;
                            entityIP.postal = model.postal;
                            entityIP.calling_code = model.calling_code;
                            entityIP.flag = model.flag;
                            entityIP.emoji_flag = model.emoji_flag;
                            entityIP.emoji_unicode = model.emoji_unicode;
                            if (asnId.IsNotNull())
                            {
                                entityIP.Asn_ID = asnId.ID;
                            }
                            else
                            {
                                entityIP.Asn_ID = -1;
                            }
                            if (CarrierId.IsNotNull())
                            {
                                entityIP.Carrier_ID = CarrierId.ID;
                            }
                            else
                            {
                                entityIP.Carrier_ID = -1;
                            }
                            if (CurrencyId.IsNotNull())
                            {
                                entityIP.Currency_ID = CurrencyId.ID;
                            }
                            else
                            {
                                entityIP.Currency_ID = -1;
                            }
                            if (LanguageId.IsNotNull())
                            {
                                entityIP.Language_ID = LanguageId.ID;
                            }
                            else
                            {
                                entityIP.Language_ID = -1;
                            }
                            if (TimeZoneId.IsNotNull())
                            {
                                entityIP.TimeZone_ID = TimeZoneId.ID;
                            }
                            else
                            {
                                entityIP.TimeZone_ID = -1;
                            }
                            if (ThreatId.IsNotNull())
                            {
                                entityIP.Threat_ID = ThreatId.ID;
                            }
                            else
                            {
                                entityIP.Threat_ID = -1;
                            }

                            entityIP.Tenant_ID = model.Tenant_ID;

                            this.businessIPInfo.Create(entityIP);

                            transaction.Complete();

                            var response = new JsonResponse<dynamic>()
                            {
                                Type = busConstant.Messages.Type.RESPONSE,
                                Title = entityIP.ID.ToString(),
                                Icon = busConstant.Messages.Icon.SUCCESS,
                                MessageCode = busConstant.Messages.MessageCode.SAVE,
                                Message = busConstant.Messages.Type.Responses.SAVE
                            };

                            return Json(response, JsonRequestBehavior.AllowGet);

                        }
                        catch (Exception ex)
                        {
                            transaction.Dispose();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return ExceptionResponse(ex);
            }
            finally
            {
                // unitOfWork.Dispose();
            }
        }

        #endregion

    }
}