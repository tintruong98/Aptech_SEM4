#pragma checksum "C:\Users\PC\Documents\Zalo Received Files\FPT_SEM4\App_WebRuou\Views\KhachHang\HuyDonHang.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "834812ee1f22adf123ff940afc2ebab59470bfa0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_KhachHang_HuyDonHang), @"mvc.1.0.view", @"/Views/KhachHang/HuyDonHang.cshtml")]
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
#line 1 "C:\Users\PC\Documents\Zalo Received Files\FPT_SEM4\App_WebRuou\Views\_ViewImports.cshtml"
using App_WebRuou;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\PC\Documents\Zalo Received Files\FPT_SEM4\App_WebRuou\Views\_ViewImports.cshtml"
using App_WebRuou.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"834812ee1f22adf123ff940afc2ebab59470bfa0", @"/Views/KhachHang/HuyDonHang.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b386eede7ba9ed4e0481890fb0fa3c66410023b5", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_KhachHang_HuyDonHang : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<App_WebRuou.Models.DonHangImage>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("templatemo-item"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\PC\Documents\Zalo Received Files\FPT_SEM4\App_WebRuou\Views\KhachHang\HuyDonHang.cshtml"
  
    ViewData["Title"] = "HuyDonHang";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""container"">
    <div class=""row"">
        <div class=""col-lg-12"">
            <div class=""page-content"">
                <div class=""gaming-library"">
                    <div class=""col-lg-auto"">
                        <div class=""heading-section"">
                            <h4><em>The order you have purchased needs </em>to be cancelled</h4>
                        </div>
                        <br />
");
#nullable restore
#line 16 "C:\Users\PC\Documents\Zalo Received Files\FPT_SEM4\App_WebRuou\Views\KhachHang\HuyDonHang.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"item\">\r\n                                <ul>\r\n                                    <li>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "834812ee1f22adf123ff940afc2ebab59470bfa05061", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 749, "~/", 749, 2, true);
#nullable restore
#line 20 "C:\Users\PC\Documents\Zalo Received Files\FPT_SEM4\App_WebRuou\Views\KhachHang\HuyDonHang.cshtml"
AddHtmlAttributeValue("", 751, item.Url, 751, 9, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n\r\n");
            WriteLiteral("\r\n                                    <li><h4>Booking date</h4><span style=\"color:white\">");
#nullable restore
#line 24 "C:\Users\PC\Documents\Zalo Received Files\FPT_SEM4\App_WebRuou\Views\KhachHang\HuyDonHang.cshtml"
                                                                                  Write(item.NgayDat.Substring(0,10));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></li>\r\n\r\n                                    <li><h4>Delivery date</h4><span style=\"color:white\">");
#nullable restore
#line 26 "C:\Users\PC\Documents\Zalo Received Files\FPT_SEM4\App_WebRuou\Views\KhachHang\HuyDonHang.cshtml"
                                                                                   Write(item.NgayGiao.Substring(0,10));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></li>\r\n\r\n                                    <li><h4>Quantity</h4><span style=\"color:white\">");
#nullable restore
#line 28 "C:\Users\PC\Documents\Zalo Received Files\FPT_SEM4\App_WebRuou\Views\KhachHang\HuyDonHang.cshtml"
                                                                              Write(item.SoLuong);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></li>\r\n\r\n                                    <li><h4>Total order</h4><span style=\"color:#ec6090\">");
#nullable restore
#line 30 "C:\Users\PC\Documents\Zalo Received Files\FPT_SEM4\App_WebRuou\Views\KhachHang\HuyDonHang.cshtml"
                                                                                   Write(item.TongTien.ToString("N").Substring(0,@item.TongTien.ToString("N").Length-3));

#line default
#line hidden
#nullable disable
            WriteLiteral(" VND</span></li>\r\n");
#nullable restore
#line 31 "C:\Users\PC\Documents\Zalo Received Files\FPT_SEM4\App_WebRuou\Views\KhachHang\HuyDonHang.cshtml"
                                     if (item.TrangThaiGH == 0)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <li><div class=\"main-button\"><a");
            BeginWriteAttribute("href", " href=\"", 1645, "\"", 1763, 1);
#nullable restore
#line 33 "C:\Users\PC\Documents\Zalo Received Files\FPT_SEM4\App_WebRuou\Views\KhachHang\HuyDonHang.cshtml"
WriteAttributeValue("", 1652, Url.Action("XemChiTieDonHang", "KhachHang", new {varLocal = item.Id,trangthaiGH=item.TrangThaiGH,mahuy="Del"}), 1652, 111, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Reject</a></div></li>\r\n");
#nullable restore
#line 34 "C:\Users\PC\Documents\Zalo Received Files\FPT_SEM4\App_WebRuou\Views\KhachHang\HuyDonHang.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </ul>\r\n                            </div>\r\n");
#nullable restore
#line 37 "C:\Users\PC\Documents\Zalo Received Files\FPT_SEM4\App_WebRuou\Views\KhachHang\HuyDonHang.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 45 "C:\Users\PC\Documents\Zalo Received Files\FPT_SEM4\App_WebRuou\Views\KhachHang\HuyDonHang.cshtml"
      
        await Html.RenderPartialAsync("_ValidationScriptsPartial");
    

#line default
#line hidden
#nullable disable
            }
            );
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<App_WebRuou.Models.DonHangImage>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
