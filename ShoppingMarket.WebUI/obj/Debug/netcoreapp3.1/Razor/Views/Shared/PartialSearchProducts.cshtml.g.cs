#pragma checksum "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Shared\PartialSearchProducts.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f7b7d092e890c30b71aef7e39a7875a542ed0612"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_PartialSearchProducts), @"mvc.1.0.view", @"/Views/Shared/PartialSearchProducts.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f7b7d092e890c30b71aef7e39a7875a542ed0612", @"/Views/Shared/PartialSearchProducts.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"93aca939dffa7fc05fba1584c1547b3f8c7cbe3f", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_PartialSearchProducts : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ShoppingMarket.WebUI.Models.ProductsViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/offer.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(" "), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-responsive"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString(" "), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/pf4.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral(@"<div class=""breadcrumbs"">
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
            BeginWriteAttribute("href", " href=\"", 638, "\"", 682, 1);
#nullable restore
#line 16 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Shared\PartialSearchProducts.cshtml"
WriteAttributeValue("", 645, Url.Action("ProductListAll", "Home"), 645, 37, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-arrow-right\" aria-hidden=\"true\"></i>Tüm Ürünler</a></li>\r\n\r\n                    <li><a");
            BeginWriteAttribute("href", " href=\"", 786, "\"", 852, 1);
#nullable restore
#line 18 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Shared\PartialSearchProducts.cshtml"
WriteAttributeValue("", 793, Url.Action("ProductsListCategory", "Home", new { id = 3 }), 793, 59, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-arrow-right\" aria-hidden=\"true\"></i>Temel Gıdalar</a></li>\r\n");
            WriteLiteral("\r\n                    <li><a");
            BeginWriteAttribute("href", " href=\"", 1452, "\"", 1518, 1);
#nullable restore
#line 32 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Shared\PartialSearchProducts.cshtml"
WriteAttributeValue("", 1459, Url.Action("ProductsListCategory", "Home", new { id = 6 }), 1459, 59, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-arrow-right\" aria-hidden=\"true\"></i>Atıştırmalık</a></li>\r\n");
            WriteLiteral("\r\n                    <li><a");
            BeginWriteAttribute("href", " href=\"", 2118, "\"", 2184, 1);
#nullable restore
#line 46 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Shared\PartialSearchProducts.cshtml"
WriteAttributeValue("", 2125, Url.Action("ProductsListCategory", "Home", new { id = 2 }), 2125, 59, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-arrow-right\" aria-hidden=\"true\"></i>Et Ve Et Ürünleri</a></li>\r\n");
            WriteLiteral("\r\n                    <li><a");
            BeginWriteAttribute("href", " href=\"", 2789, "\"", 2855, 1);
#nullable restore
#line 60 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Shared\PartialSearchProducts.cshtml"
WriteAttributeValue("", 2796, Url.Action("ProductsListCategory", "Home", new { id = 1 }), 2796, 59, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-arrow-right\" aria-hidden=\"true\"></i>Süt Ve Süt Ürünleri</a></li>\r\n");
            WriteLiteral("\r\n                    <li><a");
            BeginWriteAttribute("href", " href=\"", 3462, "\"", 3528, 1);
#nullable restore
#line 74 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Shared\PartialSearchProducts.cshtml"
WriteAttributeValue("", 3469, Url.Action("ProductsListCategory", "Home", new { id = 4 }), 3469, 59, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-arrow-right\" aria-hidden=\"true\"></i>Kahvaltılık</a></li>\r\n");
            WriteLiteral("                    <li><a");
            BeginWriteAttribute("href", " href=\"", 4125, "\"", 4191, 1);
#nullable restore
#line 87 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Shared\PartialSearchProducts.cshtml"
WriteAttributeValue("", 4132, Url.Action("ProductsListCategory", "Home", new { id = 7 }), 4132, 59, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-arrow-right\" aria-hidden=\"true\"></i>İçecekler</a></li>\r\n");
            WriteLiteral("                </ul>\r\n            </div>\r\n        </div>\r\n        <div class=\"col-md-8 products-right\">\r\n\r\n\r\n            <div class=\"agile_top_brands_grids\">\r\n");
#nullable restore
#line 107 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Shared\PartialSearchProducts.cshtml"
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "f7b7d092e890c30b71aef7e39a7875a542ed061211630", async() => {
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
                                                <a");
            BeginWriteAttribute("href", " href=\"", 5701, "\"", 5774, 1);
#nullable restore
#line 120 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Shared\PartialSearchProducts.cshtml"
WriteAttributeValue("", 5708, Url.Action("GetProduct", "Products", new { id = item.ProductId }), 5708, 66, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "f7b7d092e890c30b71aef7e39a7875a542ed061213649", async() => {
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
#line 121 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Shared\PartialSearchProducts.cshtml"
                                              Write(item.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                                <h4>");
#nullable restore
#line 122 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Shared\PartialSearchProducts.cshtml"
                                               Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" TL</h4>\r\n                                            </div>\r\n                                            <div class=\"snipcart-details top_brand_home_details\">\r\n                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f7b7d092e890c30b71aef7e39a7875a542ed061215780", async() => {
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
                WriteLiteral("cel_return\" value=\" \">\r\n                                                        <a");
                BeginWriteAttribute("href", " href=\"", 7309, "\"", 7384, 1);
#nullable restore
#line 136 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Shared\PartialSearchProducts.cshtml"
WriteAttributeValue("", 7316, Url.Action("AddToCart", "Cart", new { productId = item.ProductId }), 7316, 68, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("><input type=\"submit\" name=\"submit\" value=\"Sepete Ekle\" class=\"button\">\r\n                                                    </fieldset>\r\n                                                ");
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
#line 146 "D:\PROJELERİM\BİTİRMEPROJESİ.NETCORE\GraduationProject\ShoppingMarket.WebUI\Views\Shared\PartialSearchProducts.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"clearfix\"> </div>\r\n            </div>\r\n\r\n");
            WriteLiteral("\r\n");
            WriteLiteral("        </div>\r\n        <div class=\"clearfix\"> </div>\r\n    </div>\r\n</div>");
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
