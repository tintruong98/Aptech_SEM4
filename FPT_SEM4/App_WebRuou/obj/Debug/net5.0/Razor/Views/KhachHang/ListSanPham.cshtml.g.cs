#pragma checksum "C:\FPT_SEM4\App_WebRuou\Views\KhachHang\ListSanPham.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1c4e4671716fe04271874de3ae5431d57b6751ce"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_KhachHang_ListSanPham), @"mvc.1.0.view", @"/Views/KhachHang/ListSanPham.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1c4e4671716fe04271874de3ae5431d57b6751ce", @"/Views/KhachHang/ListSanPham.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b386eede7ba9ed4e0481890fb0fa3c66410023b5", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_KhachHang_ListSanPham : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<App_WebRuou.Models.SanPham>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("250"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("300"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\FPT_SEM4\App_WebRuou\Views\KhachHang\ListSanPham.cshtml"
  
    ViewData["Title"] = "ListSanPham";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container\">\r\n    <div class=\"page-content\">\r\n        <div class=\"gaming-library\">\r\n            <table width=\"100%\" cellpadding=\"5\">\r\n");
#nullable restore
#line 11 "C:\FPT_SEM4\App_WebRuou\Views\KhachHang\ListSanPham.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td width=\"25%\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "1c4e4671716fe04271874de3ae5431d57b6751ce4876", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 415, "~/", 415, 2, true);
#nullable restore
#line 15 "C:\FPT_SEM4\App_WebRuou\Views\KhachHang\ListSanPham.cshtml"
AddHtmlAttributeValue("", 417, item.UrlImage, 417, 14, false);

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
            WriteLiteral("\r\n                        </td>\r\n                        <td width=\"75%\">\r\n                            <p><a style=\"color:aqua; font-size:large\">");
#nullable restore
#line 18 "C:\FPT_SEM4\App_WebRuou\Views\KhachHang\ListSanPham.cshtml"
                                                                 Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></p>\r\n                            <p class=\"text-justify\"><a style=\"color:white; font-family:\'Segoe UI\', Tahoma, Geneva, Verdana, sans-serif; font-size:small\">");
#nullable restore
#line 19 "C:\FPT_SEM4\App_WebRuou\Views\KhachHang\ListSanPham.cshtml"
                                                                                                                                                    Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></p>\r\n                            <center>\r\n                                <p><a style=\"color:red ; font-family:\'Segoe UI\', Tahoma, Geneva, Verdana, sans-serif; font-size:large\">");
#nullable restore
#line 21 "C:\FPT_SEM4\App_WebRuou\Views\KhachHang\ListSanPham.cshtml"
                                                                                                                                  Write(item.Price.ToString("N").Substring(0,@item.Price.ToString("N").Length-3));

#line default
#line hidden
#nullable disable
            WriteLiteral(" VND</a></p>\r\n                            </center>\r\n                            <p><a style=\"color:yellow; font-family:\'Segoe UI\', Tahoma, Geneva, Verdana, sans-serif; font-size:12px\">Còn ");
#nullable restore
#line 23 "C:\FPT_SEM4\App_WebRuou\Views\KhachHang\ListSanPham.cshtml"
                                                                                                                                   Write(item.Soluong.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral(" sản phẩm</a></p>\r\n");
#nullable restore
#line 24 "C:\FPT_SEM4\App_WebRuou\Views\KhachHang\ListSanPham.cshtml"
                             if (string.IsNullOrEmpty(ViewBag.UserName_))
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                <center>
                                    <a href=""#"">
                                        <span class=""btn btn-success"">Thêm vào giỏ hàng </span>
                                    </a>
                                    <p><a style=""color:white; font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size:small"">Đăng nhập để thực hiện chức năng thêm vào giỏ hàng</a></p>
                                </center>
");
#nullable restore
#line 32 "C:\FPT_SEM4\App_WebRuou\Views\KhachHang\ListSanPham.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <center>\r\n                                    <a");
            BeginWriteAttribute("href", " href=\"", 2044, "\"", 2111, 1);
#nullable restore
#line 36 "C:\FPT_SEM4\App_WebRuou\Views\KhachHang\ListSanPham.cshtml"
WriteAttributeValue("", 2051, Url.Action("AddToCart", "KhachHang",new {varLocal=item.Id}), 2051, 60, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                        <span class=\"btn btn-success\">Thêm vào giỏ hàng </span>\r\n                                    </a>\r\n                                </center>\r\n");
#nullable restore
#line 40 "C:\FPT_SEM4\App_WebRuou\Views\KhachHang\ListSanPham.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 43 "C:\FPT_SEM4\App_WebRuou\Views\KhachHang\ListSanPham.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </table>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 49 "C:\FPT_SEM4\App_WebRuou\Views\KhachHang\ListSanPham.cshtml"
      
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<App_WebRuou.Models.SanPham>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
