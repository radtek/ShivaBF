jQuery.support.cors = true;

var tenantId = 1;

$(function () {
    $.getScript('Scripts/ViewsJS/common.js', function () {
        baseApiUrl = GetbaseApiUrl();
        baseHtmlPath = GetbaseHtmlPath();

        url = getUrlVars()["u"];
        GetServiceType4ByTenantIdAndUrl(tenantId, url);
        //load section1
        var Id = document.getElementById("hdnService_Id").value;
        if (Id != "0" && Id != "undefined") {
            GetServiceType4Section2FAQMappingByTenantIdAndServiceId(tenantId, Id);
            //load section 3
            GetServiceType4Section345MasterByTenantIdAndServiceId(tenantId, Id, 'SEC1',1);
            //load section 4
            GetServiceType4Section345MasterByTenantIdAndServiceId(tenantId, Id, 'SEC1', 2);
            //load section 5
            GetServiceType4Section345MasterByTenantIdAndServiceId(tenantId, Id, 'SEC1', 3);
            //load section 4Master
           // GetServiceType4Section4MasterByTenantIdAndServiceId(tenantId, Id);
        }
    });
});


function GetServiceType4ByTenantIdAndUrl(tenantId, url) {
    //debugger;
    jQuery.support.cors = true;
    var serviceURL = baseApiUrl + "api/ServiceType4/GetServiceType4ByTenantIdAndUrl/" + tenantId + "/" + url;
    //$("#loader").show();
    $.ajax({
        type: "GET", //rest Type
        dataType: 'json', //mispelled
        url: serviceURL,
        contentType: "application/json; charset=utf-8",
        crossDomain: true,
        async: false,
        success: function (data) {
            console.log(data);
            document.getElementById("hdnService_Id").setAttribute("value", data.ID);
            document.getElementById("sectionBannerImagePath").setAttribute("style", "background-image:url('" + data.BannerImagePath + "')");
            //$('#imgBannerImagePath').set = data.BannerImagePath;
            var divBannerSection = '<div class="auto-container"><div class="content content-head">';
            divBannerSection += '<h1 >' + data.BannerOnHeading + '</h1>';
            divBannerSection += '<p class="lead text-center">' + data.BannerHeadingDescription + '</p>';
            divBannerSection += '</div></div>';
            $('#sectionBannerImagePath').html(divBannerSection);
            $('#pSection1Description').html(data.Section1Description);
            $('#divSection1FAQDescription').html(data.Section2FAQDescription);
            $('#divSection2PriceingHeading').html(data.Section2PriceingHeading);
            $('#divSection2PriceingHeadingDescription').html(data.Section2PriceingHeadingDescription);
            $('#divSection3PriceingHeading').html(data.Section3PriceingHeading);
            $('#divSection3PriceingHeadingDescription').html(data.Section3PriceingHeadingDescription);
            $('#divSection4PriceingHeading').html(data.Section4PriceingHeading);
            $('#divSection4PriceingHeadingDescription').html(data.Section4PriceingHeadingDescription);
            $('#h3Section5PriceingHeading').html(data.Section5PriceingHeading);
            $('#divSection6PriceingHeading').html(data.Section6PriceingHeading);
            $('#divSection7PriceingHeading').html(data.Section7PriceingHeading);
          
        }
    });
    
    return false;

}
function GetServiceType4Section345MasterByTenantIdAndServiceId(tenantId, Id, SectionTypeValue,sectionid) {
    //debugger;
    jQuery.support.cors = true;
    var serviceURL = baseApiUrl + "api/ServiceType1/GetServiceType4Section345MasterByTenantIdAndServiceId/" + tenantId + "/" + Id + "/" + SectionTypeValue;
    //$("#loader").show();
    $.ajax({
        type: "GET", //rest Type
        dataType: 'json', //mispelled
        url: serviceURL,
        contentType: "application/json; charset=utf-8",
        crossDomain: true,
        success: function (data) {
            console.log(data);
            $('#divPriceMasterSection'+sectionid).html('');
            var contentSection345PriceMaster = "";
            if (data.length <= 0) {
                document.getElementById("sectionPriceMasterSection"+sectionid).setAttribute("style", "display:none");
            }
            else {
                document.getElementById("sectionPriceMasterSection" + sectionid).setAttribute("style", "display:inline");
            }
            data.forEach(function (item) {
                contentSection345PriceMaster += '<div class="price-block price-table4 col-lg-3 col-md-6 col-sm-12"><div class="inner-box">';
                contentSection345PriceMaster += '<div class="title-box"><h5>' + item.Heading + '</h5></div>';
                contentSection345PriceMaster += '<div class="price"><ul class="plan-heading">';
                item.Services4Section345MasterFeaturesDetailsViewModel.forEach(function (subitem) {
                    contentSection345PriceMaster += '<li>' + subitem.ShortDescription + '</li>';
                });       
                contentSection345PriceMaster += '</ul></div>';
                item.Services4Section345MasterButtonsChildViewModel.forEach(function (subitemCB) {
                    contentSection345PriceMaster += '<div class="lower-box bg-price">';
                    contentSection345PriceMaster += '<p>' + subitemCB.FeatureDescription + '- ₹ ' + subitemCB.Price + '</p>';
                    contentSection345PriceMaster += '<a href="' + subitemCB.AncharTagUrl + '" class="theme-btn btn-style-eight">' + subitemCB.AncharTagTitle + '</a>';
                    contentSection345PriceMaster += '</div>';
                });  
				contentSection345PriceMaster += '</div></div>';
                
            });
            //   contentsection4 += '</div>';
            $('#divPriceMasterSection' + sectionid).html(contentSection6PriceMaster);
        }
    });

    return false;

}

function GetServiceType4Section2FAQMappingByTenantIdAndServiceId(tenantId, Id) {
    //debugger;
    jQuery.support.cors = true;
    var serviceURL = baseApiUrl + "api/ServiceType4/GetServiceType4Section2FAQMappingByTenantIdAndServiceId/" + tenantId + "/" + Id;
    //$("#loader").show();
    $.ajax({
        type: "GET", //rest Type
        dataType: 'json', //mispelled
        url: serviceURL,
        contentType: "application/json; charset=utf-8",
        crossDomain: true,
        success: function (data) {
            console.log(data);
            $('#divSection2FAQMapping').html('');
            var contentSection2FAQMapping = "";
           
           // alert(count);
            data.forEach(function (item) {
               
                    contentSection2FAQMapping += '<div class="accordionItem close">';
                    contentSection2FAQMapping += '<h5 class="accordionItemHeading"><i class="fa fa-angle-down"></i>'+item.Title+'</h5>';
                    contentSection2FAQMapping += '<div class="accordionItemContent">';
                    contentSection2FAQMapping += '<p>' + item.Description + '</p>';
                    contentSection2FAQMapping += '</div></div>';

            });
            
            //   contentsection4 += '</div>';
            $('#divSection2FAQMapping').html(contentSection2FAQMapping);
            var accItem = document.getElementsByClassName('accordionItem');
            var accHD = document.getElementsByClassName('accordionItemHeading');
            for (i = 0; i < accHD.length; i++) {
                accHD[i].addEventListener('click', toogle, false);
            }
            function toogle() {
                var itemClass = this.parentNode.className;
                for (i = 0; i < accItem.length; i++) {
                    accItem[i].className = 'accordionItem close';
                }
                if (itemClass == 'accordionItem close') {
                    this.parentNode.className = 'accordionItem open';
                }
            }
        }
    });

    return false;

   
}
function GetServiceType4Section678MasterByTenantIdAndServiceId(tenantId, Id, SectionTypeValue, sectionid) {
    //debugger;
    jQuery.support.cors = true;
    var serviceURL = baseApiUrl + "api/ServiceType1/GetServiceType4Section678MasterByTenantIdAndServiceId/" + tenantId + "/" + Id + "/" + SectionTypeValue;
    //$("#loader").show();
    $.ajax({
        type: "GET", //rest Type
        dataType: 'json', //mispelled
        url: serviceURL,
        contentType: "application/json; charset=utf-8",
        crossDomain: true,
        success: function (data) {
            console.log(data);
            $('#divPriceMasterSection' + sectionid).html('');
            var contentSection345PriceMaster = "";
            if (data.length <= 0) {
                document.getElementById("sectionPriceMasterSection" + sectionid).setAttribute("style", "display:none");
            }
            else {
                document.getElementById("sectionPriceMasterSection" + sectionid).setAttribute("style", "display:inline");
            }
            for (let i = 0; i < data.length; i++) {

                let childArray = data[i].ServiceType4Section678FieldMasterViewModel;

                for (let j = 0; j < childArray.length; j++) {

                    console.log(childArray[j]);

                }

            }
            //   contentsection4 += '</div>';
            $('#divPriceMasterSection' + sectionid).html(contentSection6PriceMaster);
        }
    });

    return false;

}

function getUrlVars() {
    var vars = [], hash;
    var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var i = 0; i < hashes.length; i++) {
        hash = hashes[i].split('=');
        vars.push(hash[0]);
        vars[hash[0]] = hash[1];
    }
    return vars;
}