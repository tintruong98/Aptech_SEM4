#pragma checksum "C:\Users\PC\Documents\Zalo Received Files\FPT_SEM4\App_WebRuou\Views\KhachHang\NhanXetKhachHang.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "907971e01b1ee6a9e76f3548247036fb618735da"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_KhachHang_NhanXetKhachHang), @"mvc.1.0.view", @"/Views/KhachHang/NhanXetKhachHang.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"907971e01b1ee6a9e76f3548247036fb618735da", @"/Views/KhachHang/NhanXetKhachHang.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b386eede7ba9ed4e0481890fb0fa3c66410023b5", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_KhachHang_NhanXetKhachHang : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<App_WebRuou.Models.FeedBackDetails>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"row\">\r\n");
#nullable restore
#line 3 "C:\Users\PC\Documents\Zalo Received Files\FPT_SEM4\App_WebRuou\Views\KhachHang\NhanXetKhachHang.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <div class=""col-lg-6 col-sm-6"">
            <div class=""item"">
                <table width=""100%"" cellpadding=""10"">
                    <tr>
                        <td>
                            <p>
                                <a style=""color:yellow ; font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size:14px"">");
#nullable restore
#line 11 "C:\Users\PC\Documents\Zalo Received Files\FPT_SEM4\App_WebRuou\Views\KhachHang\NhanXetKhachHang.cshtml"
                                                                                                                                 Write(item.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                            </p>\r\n                            <p>\r\n                                <a style=\"color:white ; font-family:\'Segoe UI\', Tahoma, Geneva, Verdana, sans-serif; font-size:14px\">");
#nullable restore
#line 14 "C:\Users\PC\Documents\Zalo Received Files\FPT_SEM4\App_WebRuou\Views\KhachHang\NhanXetKhachHang.cshtml"
                                                                                                                                Write(item.Contents);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                            </p>\r\n                            <p>\r\n");
#nullable restore
#line 17 "C:\Users\PC\Documents\Zalo Received Files\FPT_SEM4\App_WebRuou\Views\KhachHang\NhanXetKhachHang.cshtml"
                                 if (item.Evaluate == 5)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    <i class=""fa fa-star fa-1"" style=""color:yellow""></i>
                                    <i class=""fa fa-star fa-1"" style=""color:yellow""></i>
                                    <i class=""fa fa-star fa-1"" style=""color:yellow""></i>
                                    <i class=""fa fa-star fa-1"" style=""color:yellow""></i>
                                    <i class=""fa fa-star fa-1"" style=""color:yellow""></i>
");
#nullable restore
#line 24 "C:\Users\PC\Documents\Zalo Received Files\FPT_SEM4\App_WebRuou\Views\KhachHang\NhanXetKhachHang.cshtml"
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "C:\Users\PC\Documents\Zalo Received Files\FPT_SEM4\App_WebRuou\Views\KhachHang\NhanXetKhachHang.cshtml"
                                 if (item.Evaluate == 4)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    <i class=""fa fa-star fa-1"" style=""color:yellow""></i>
                                    <i class=""fa fa-star fa-1"" style=""color:yellow""></i>
                                    <i class=""fa fa-star fa-1"" style=""color:yellow""></i>
                                    <i class=""fa fa-star fa-1"" style=""color:yellow""></i>
                                    <i class=""fa fa-star fa-1"" style=""color:gainsboro""></i>
");
#nullable restore
#line 32 "C:\Users\PC\Documents\Zalo Received Files\FPT_SEM4\App_WebRuou\Views\KhachHang\NhanXetKhachHang.cshtml"
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 33 "C:\Users\PC\Documents\Zalo Received Files\FPT_SEM4\App_WebRuou\Views\KhachHang\NhanXetKhachHang.cshtml"
                                 if (item.Evaluate == 3)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    <i class=""fa fa-star fa-1"" style=""color:yellow""></i>
                                    <i class=""fa fa-star fa-1"" style=""color:yellow""></i>
                                    <i class=""fa fa-star fa-1"" style=""color:yellow""></i>
                                    <i class=""fa fa-star fa-1"" style=""color:gainsboro""></i>
                                    <i class=""fa fa-star fa-1"" style=""color:gainsboro""></i>
");
#nullable restore
#line 40 "C:\Users\PC\Documents\Zalo Received Files\FPT_SEM4\App_WebRuou\Views\KhachHang\NhanXetKhachHang.cshtml"
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 41 "C:\Users\PC\Documents\Zalo Received Files\FPT_SEM4\App_WebRuou\Views\KhachHang\NhanXetKhachHang.cshtml"
                                 if (item.Evaluate == 2)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    <i class=""fa fa-star fa-1"" style=""color:yellow""></i>
                                    <i class=""fa fa-star fa-1"" style=""color:yellow""></i>
                                    <i class=""fa fa-star fa-1"" style=""color:gainsboro""></i>
                                    <i class=""fa fa-star fa-1"" style=""color:gainsboro""></i>
                                    <i class=""fa fa-star fa-1"" style=""color:gainsboro""></i>
");
#nullable restore
#line 48 "C:\Users\PC\Documents\Zalo Received Files\FPT_SEM4\App_WebRuou\Views\KhachHang\NhanXetKhachHang.cshtml"
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 49 "C:\Users\PC\Documents\Zalo Received Files\FPT_SEM4\App_WebRuou\Views\KhachHang\NhanXetKhachHang.cshtml"
                                 if (item.Evaluate == 1)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    <i class=""fa fa-star fa-1"" style=""color:yellow""></i>
                                    <i class=""fa fa-star fa-1"" style=""color:gainsboro""></i>
                                    <i class=""fa fa-star fa-1"" style=""color:gainsboro""></i>
                                    <i class=""fa fa-star fa-1"" style=""color:gainsboro""></i>
                                    <i class=""fa fa-star fa-1"" style=""color:gainsboro""></i>
");
#nullable restore
#line 56 "C:\Users\PC\Documents\Zalo Received Files\FPT_SEM4\App_WebRuou\Views\KhachHang\NhanXetKhachHang.cshtml"
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 57 "C:\Users\PC\Documents\Zalo Received Files\FPT_SEM4\App_WebRuou\Views\KhachHang\NhanXetKhachHang.cshtml"
                                 if (item.Evaluate == 0)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    <i class=""fa fa-star fa-1"" style=""color:gainsboro""></i>
                                    <i class=""fa fa-star fa-1"" style=""color:gainsboro""></i>
                                    <i class=""fa fa-star fa-1"" style=""color:gainsboro""></i>
                                    <i class=""fa fa-star fa-1"" style=""color:gainsboro""></i>
                                    <i class=""fa fa-star fa-1"" style=""color:g""></i>
");
#nullable restore
#line 64 "C:\Users\PC\Documents\Zalo Received Files\FPT_SEM4\App_WebRuou\Views\KhachHang\NhanXetKhachHang.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </p>\r\n                        </td>\r\n                    </tr>\r\n                </table>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 71 "C:\Users\PC\Documents\Zalo Received Files\FPT_SEM4\App_WebRuou\Views\KhachHang\NhanXetKhachHang.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<App_WebRuou.Models.FeedBackDetails>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591