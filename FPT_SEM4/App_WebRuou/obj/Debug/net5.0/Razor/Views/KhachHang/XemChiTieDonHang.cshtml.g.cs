#pragma checksum "C:\FPT_SEM4\App_WebRuou\Views\KhachHang\XemChiTieDonHang.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "49ee8921cfd7638c58382775992c9c3fb9eda4ff"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_KhachHang_XemChiTieDonHang), @"mvc.1.0.view", @"/Views/KhachHang/XemChiTieDonHang.cshtml")]
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
#line 1 "C:\FPT_SEM4\App_WebRuou\Views\_ViewImports.cshtml"
using App_WebRuou;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\FPT_SEM4\App_WebRuou\Views\_ViewImports.cshtml"
using App_WebRuou.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"49ee8921cfd7638c58382775992c9c3fb9eda4ff", @"/Views/KhachHang/XemChiTieDonHang.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b386eede7ba9ed4e0481890fb0fa3c66410023b5", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_KhachHang_XemChiTieDonHang : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<App_WebRuou.Models.DetailsDonHang>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("300"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("330"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\FPT_SEM4\App_WebRuou\Views\KhachHang\XemChiTieDonHang.cshtml"
  
    ViewData["Title"] = "XemChiTieDonHang";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""container"">
    <div class=""row"">
        <div class=""col-lg-12"">
            <div class=""page-content"">
                <div class=""gaming-library"">
                    <div class=""col-lg-12"">
                        <div class=""heading-section"">
                            <h4><em>Sản phẩm bạn đã </em>mua</h4>
                        </div>
");
#nullable restore
#line 15 "C:\FPT_SEM4\App_WebRuou\Views\KhachHang\XemChiTieDonHang.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            <div>
                                <ul>
                                    <a style=""color:white; font-size:large"">Tổng giá trị đơn hàng:</a>
                                    <li><a style=""color:crimson ; font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size:large"">");
#nullable restore
#line 20 "C:\FPT_SEM4\App_WebRuou\Views\KhachHang\XemChiTieDonHang.cshtml"
                                                                                                                                           Write(ViewBag.Tonggiatri);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" VND</a></li>
                                </ul>
                            </div>
                            <br />
                            <div>
                                <center>
                                    <ul>
                                        <li>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "49ee8921cfd7638c58382775992c9c3fb9eda4ff6010", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1195, "~/", 1195, 2, true);
#nullable restore
#line 27 "C:\FPT_SEM4\App_WebRuou\Views\KhachHang\XemChiTieDonHang.cshtml"
AddHtmlAttributeValue("", 1197, item.UrlImage, 1197, 14, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
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
            WriteLiteral(@"</li>
                                    </ul>
                                </center>
                            </div>
                            <div>
                                <ul>
                                    <h5 style=""color:white"">");
#nullable restore
#line 33 "C:\FPT_SEM4\App_WebRuou\Views\KhachHang\XemChiTieDonHang.cshtml"
                                                       Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h5>
                                </ul>
                            </div>
                            <div>
                                <ul>
                                    <li><a style=""color:white; font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size:small"">");
#nullable restore
#line 38 "C:\FPT_SEM4\App_WebRuou\Views\KhachHang\XemChiTieDonHang.cshtml"
                                                                                                                                        Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a></li>
                                </ul>
                            </div>
                            <div>
                                <ul>
                                    <a style=""color:white; font-size:large"">Số lượng:</a>
                                    <li><a style=""color:white; font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size:medium"">");
#nullable restore
#line 44 "C:\FPT_SEM4\App_WebRuou\Views\KhachHang\XemChiTieDonHang.cshtml"
                                                                                                                                         Write(item.SoLuong);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a></li>
                                </ul>
                            </div>
                            <div>
                                <ul>
                                    <a style=""color:white; font-size:large"">Đơn giá:</a>
                                    <li><a style=""color:white ; font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size:large"">");
#nullable restore
#line 50 "C:\FPT_SEM4\App_WebRuou\Views\KhachHang\XemChiTieDonHang.cshtml"
                                                                                                                                         Write(item.GiaTien.ToString("N").Substring(0,@item.GiaTien.ToString("N").Length-3));

#line default
#line hidden
#nullable disable
            WriteLiteral(@" VND</a></li>
                                </ul>
                            </div>
                            <div>
                                <ul>
                                    <a style=""color:white; font-size:large"">Thành tiền:</a>
                                    <li><a style=""color:crimson ; font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size:large"">");
#nullable restore
#line 56 "C:\FPT_SEM4\App_WebRuou\Views\KhachHang\XemChiTieDonHang.cshtml"
                                                                                                                                           Write(item.ThanhTien.ToString("N").Substring(0,@item.ThanhTien.ToString("N").Length-3));

#line default
#line hidden
#nullable disable
            WriteLiteral(@" VND</a></li>
                                </ul>
                            </div>
                            <div>
                                <ul>
                                    <a style=""color:white; font-size:large"">Khuyến mãi:</a>
                                    <li><a style=""color:white ; font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size:medium"">");
#nullable restore
#line 62 "C:\FPT_SEM4\App_WebRuou\Views\KhachHang\XemChiTieDonHang.cshtml"
                                                                                                                                          Write(item.Promotion.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral(" %</a></li>\r\n                                </ul>\r\n                            </div>\r\n                            <br />\r\n                            <br />\r\n");
#nullable restore
#line 67 "C:\FPT_SEM4\App_WebRuou\Views\KhachHang\XemChiTieDonHang.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 75 "C:\FPT_SEM4\App_WebRuou\Views\KhachHang\XemChiTieDonHang.cshtml"
      
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<App_WebRuou.Models.DetailsDonHang>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
