#pragma checksum "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Products\Get.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "02a2c8d84ca209a5c7dbc3a8434ce7153301b029"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Products_Get), @"mvc.1.0.view", @"/Views/Products/Get.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\_ViewImports.cshtml"
using ShoppingMarket.WebUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\_ViewImports.cshtml"
using ShoppingMarket.WebUI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\_ViewImports.cshtml"
using ShoppingMarket.WebUI.Extensions;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"02a2c8d84ca209a5c7dbc3a8434ce7153301b029", @"/Views/Products/Get.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"93aca939dffa7fc05fba1584c1547b3f8c7cbe3f", @"/Views/_ViewImports.cshtml")]
    public class Views_Products_Get : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ShoppingMarket.WebUI.Models.ProductsViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/offer.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(" "), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-responsive"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString(" "), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/pf4.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("#"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Products\Get.cshtml"
  
    ViewData["Title"] = "Get";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""breadcrumbs"">
    <div class=""container"">
        <ol class=""breadcrumb breadcrumb1 animated wow slideInLeft"" data-wow-delay="".5s"">
            <li><a href=""index.html""><span class=""glyphicon glyphicon-home"" aria-hidden=""true""></span>Anasayfa</a></li>
            <li class=""active"">Ürünler</li>
        </ol>
    </div>
</div>
<div class=""products"">
    <div class=""container"">
        <div class=""col-md-4 products-left"">
            <div class=""categories"">
                <h2>Kategoriler</h2>
                <ul class=""cate"">
                    <li><a");
            BeginWriteAttribute("href", " href=\"", 726, "\"", 787, 1);
#nullable restore
#line 21 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Products\Get.cshtml"
WriteAttributeValue("", 733, Url.Action("GetCategory", "Products", new { id = 3 }), 733, 54, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-arrow-right\" aria-hidden=\"true\"></i>Temel Gıdalar</a></li>\r\n");
#nullable restore
#line 22 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Products\Get.cshtml"
                     foreach (var item in Model.Products)
                    {
                        if (item.CategoryId == 3)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <ul>\r\n                                <li><a");
            BeginWriteAttribute("href", " href=\"", 1097, "\"", 1170, 1);
#nullable restore
#line 27 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Products\Get.cshtml"
WriteAttributeValue("", 1104, Url.Action("GetProduct", "Products", new { id = item.ProductId }), 1104, 66, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-arrow-right\" aria-hidden=\"true\"></i>");
#nullable restore
#line 27 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Products\Get.cshtml"
                                                                                                                                                                Write(item.Brand);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 27 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Products\Get.cshtml"
                                                                                                                                                                            Write(item.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n\r\n                            </ul>\r\n");
#nullable restore
#line 30 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Products\Get.cshtml"
                        }


                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    \r\n                    <li><a");
            BeginWriteAttribute("href", " href=\"", 1403, "\"", 1464, 1);
#nullable restore
#line 35 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Products\Get.cshtml"
WriteAttributeValue("", 1410, Url.Action("GetCategory", "Products", new { id = 6 }), 1410, 54, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-arrow-right\" aria-hidden=\"true\"></i>Atıştırmalık</a></li>\r\n");
#nullable restore
#line 36 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Products\Get.cshtml"
                     foreach (var item in Model.Products)
                    {
                        if (item.CategoryId == 6)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <ul>\r\n                                <li><a");
            BeginWriteAttribute("href", " href=\"", 1773, "\"", 1846, 1);
#nullable restore
#line 41 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Products\Get.cshtml"
WriteAttributeValue("", 1780, Url.Action("GetProduct", "Products", new { id = item.ProductId }), 1780, 66, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-arrow-right\" aria-hidden=\"true\"></i>");
#nullable restore
#line 41 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Products\Get.cshtml"
                                                                                                                                                                Write(item.Brand);

#line default
#line hidden
#nullable disable
            WriteLiteral("  ");
#nullable restore
#line 41 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Products\Get.cshtml"
                                                                                                                                                                             Write(item.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n\r\n                            </ul>\r\n");
#nullable restore
#line 44 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Products\Get.cshtml"
                        }


                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <li><a");
            BeginWriteAttribute("href", " href=\"", 2060, "\"", 2121, 1);
#nullable restore
#line 49 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Products\Get.cshtml"
WriteAttributeValue("", 2067, Url.Action("GetCategory", "Products", new { id = 2 }), 2067, 54, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-arrow-right\" aria-hidden=\"true\"></i>Et Ve Et Ürünleri</a></li>\r\n");
#nullable restore
#line 50 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Products\Get.cshtml"
                     foreach (var item in Model.Products)
                    {
                        if (item.CategoryId == 2)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <ul>\r\n                                <li><a");
            BeginWriteAttribute("href", " href=\"", 2435, "\"", 2508, 1);
#nullable restore
#line 55 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Products\Get.cshtml"
WriteAttributeValue("", 2442, Url.Action("GetProduct", "Products", new { id = item.ProductId }), 2442, 66, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-arrow-right\" aria-hidden=\"true\"></i>");
#nullable restore
#line 55 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Products\Get.cshtml"
                                                                                                                                                                Write(item.Brand);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 55 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Products\Get.cshtml"
                                                                                                                                                                            Write(item.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a> </li>\r\n\r\n                            </ul>\r\n");
#nullable restore
#line 58 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Products\Get.cshtml"
                        }


                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <li><a");
            BeginWriteAttribute("href", " href=\"", 2722, "\"", 2783, 1);
#nullable restore
#line 63 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Products\Get.cshtml"
WriteAttributeValue("", 2729, Url.Action("GetCategory", "Products", new { id = 1 }), 2729, 54, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-arrow-right\" aria-hidden=\"true\"></i>Süt Ve Süt Ürünleri</a></li>\r\n");
#nullable restore
#line 64 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Products\Get.cshtml"
                     foreach (var item in Model.Products)
                    {
                        if (item.CategoryId == 1)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <ul>\r\n                                <li><a");
            BeginWriteAttribute("href", " href=\"", 3099, "\"", 3172, 1);
#nullable restore
#line 69 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Products\Get.cshtml"
WriteAttributeValue("", 3106, Url.Action("GetProduct", "Products", new { id = item.ProductId }), 3106, 66, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-arrow-right\" aria-hidden=\"true\"></i>");
#nullable restore
#line 69 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Products\Get.cshtml"
                                                                                                                                                                Write(item.Brand);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 69 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Products\Get.cshtml"
                                                                                                                                                                            Write(item.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a> </li>\r\n\r\n                            </ul>\r\n");
#nullable restore
#line 72 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Products\Get.cshtml"
                        }


                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <li><a");
            BeginWriteAttribute("href", " href=\"", 3386, "\"", 3447, 1);
#nullable restore
#line 77 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Products\Get.cshtml"
WriteAttributeValue("", 3393, Url.Action("GetCategory", "Products", new { id = 4 }), 3393, 54, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-arrow-right\" aria-hidden=\"true\"></i>Kahvaltılık</a></li>\r\n");
#nullable restore
#line 78 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Products\Get.cshtml"
                     foreach (var item in Model.Products)
                    {
                        if (item.CategoryId == 4)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <ul>\r\n                                <li><a");
            BeginWriteAttribute("href", " href=\"", 3755, "\"", 3828, 1);
#nullable restore
#line 83 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Products\Get.cshtml"
WriteAttributeValue("", 3762, Url.Action("GetProduct", "Products", new { id = item.ProductId }), 3762, 66, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-arrow-right\" aria-hidden=\"true\"></i>");
#nullable restore
#line 83 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Products\Get.cshtml"
                                                                                                                                                                Write(item.Brand);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 83 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Products\Get.cshtml"
                                                                                                                                                                            Write(item.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a> </li>\r\n\r\n                            </ul>\r\n");
#nullable restore
#line 86 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Products\Get.cshtml"
                        }


                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li><a");
            BeginWriteAttribute("href", " href=\"", 4040, "\"", 4101, 1);
#nullable restore
#line 90 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Products\Get.cshtml"
WriteAttributeValue("", 4047, Url.Action("GetCategory", "Products", new { id = 7 }), 4047, 54, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-arrow-right\" aria-hidden=\"true\"></i>İçecekler</a></li>\r\n");
#nullable restore
#line 91 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Products\Get.cshtml"
                     foreach (var item in Model.Products)
                    {
                        if (item.CategoryId == 7)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <ul>\r\n                                <li><a");
            BeginWriteAttribute("href", " href=\"", 4407, "\"", 4480, 1);
#nullable restore
#line 96 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Products\Get.cshtml"
WriteAttributeValue("", 4414, Url.Action("GetProduct", "Products", new { id = item.ProductId }), 4414, 66, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-arrow-right\" aria-hidden=\"true\"></i>");
#nullable restore
#line 96 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Products\Get.cshtml"
                                                                                                                                                                Write(item.Brand);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 96 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Products\Get.cshtml"
                                                                                                                                                                            Write(item.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a> </li>\r\n\r\n                            </ul>\r\n");
#nullable restore
#line 99 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Products\Get.cshtml"
                        }


                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </ul>\r\n            </div>\r\n        </div>\r\n        <div class=\"col-md-8 products-right\">\r\n");
            WriteLiteral("\r\n            <div class=\"agile_top_brands_grids\">\r\n");
#nullable restore
#line 130 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Products\Get.cshtml"
                 foreach (var item in Model.Products)
                 {
                            

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div class=""col-md-4 top_brand_left"">
                        <div class=""hover14 column"">
                            <div class=""agile_top_brand_left_grid"">
                                <div class=""agile_top_brand_left_grid_pos"">
                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "02a2c8d84ca209a5c7dbc3a8434ce7153301b02923478", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                </div>
                                <div class=""agile_top_brand_left_grid1"">
                                    <figure>
                                        <div class=""snipcart-item block"">
                                            <div class=""snipcart-thumb"">
                                                <a href=""single.html"">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "02a2c8d84ca209a5c7dbc3a8434ce7153301b02925062", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</a>\r\n                                                <p>");
#nullable restore
#line 144 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Products\Get.cshtml"
                                              Write(item.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                                <h4>");
#nullable restore
#line 145 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Products\Get.cshtml"
                                               Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" TL</h4>\r\n                                            </div>\r\n                                            <div class=\"snipcart-details top_brand_home_details\">\r\n                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "02a2c8d84ca209a5c7dbc3a8434ce7153301b02927161", async() => {
                WriteLiteral(@"
                                                    <fieldset>
                                                        <input type=""hidden"" name=""cmd"" value=""_cart"">
                                                        <input type=""hidden"" name=""add"" value=""1"">
                                                        <input type=""hidden"" name=""business"" value="" "">
                                                        <input type=""hidden"" name=""item_name"" value=""Fortune Sunflower Oil"">
                                                        <input type=""hidden"" name=""amount"" value=""35.99"">
                                                        <input type=""hidden"" name=""discount_amount"" value=""1.00"">
                                                        <input type=""hidden"" name=""currency_code"" value=""USD"">
                                                        <input type=""hidden"" name=""return"" value="" "">
                                                        <input type=""hidden"" name=""can");
                WriteLiteral(@"cel_return"" value="" "">
                                                        <input type=""submit"" name=""submit"" value=""Sepete Ekle"" class=""button"">
                                                    </fieldset>
                                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                            </div>
                                        </div>
                                    </figure>
                                </div>
                            </div>
                        </div>
                    </div>
");
#nullable restore
#line 169 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Products\Get.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n                <div class=\"clearfix\"> </div>\r\n            </div>\r\n");
            WriteLiteral(@"            <nav class=""numbering"">
                <ul class=""pagination paging"">
                    <li>
                        <a href=""#"" aria-label=""Previous"">
                            <span aria-hidden=""true"">«</span>
                        </a>
                    </li>
                    <li class=""active""><a href=""#"">1<span class=""sr-only"">(current)</span></a></li>
                    <li><a href=""#"">2</a></li>
                    <li><a href=""#"">3</a></li>
                    <li><a href=""#"">4</a></li>
                    <li><a href=""#"">5</a></li>
                    <li>
                        <a href=""#"" aria-label=""Next"">
                            <span aria-hidden=""true"">»</span>
                        </a>
                    </li>
                </ul>
            </nav>
        </div>
        <div class=""clearfix""> </div>
    </div>
</div>


");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ShoppingMarket.WebUI.Models.ProductsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
