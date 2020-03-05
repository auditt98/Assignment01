#pragma checksum "E:\Repos\Assignment01\Assignment01\Views\DanhMuc\TinhThanh\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d693a3511b326f7b624d2382553fde73b7e5482b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_DanhMuc_TinhThanh_Index), @"mvc.1.0.view", @"/Views/DanhMuc/TinhThanh/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/DanhMuc/TinhThanh/Index.cshtml", typeof(AspNetCore.Views_DanhMuc_TinhThanh_Index))]
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
#line 1 "E:\Repos\Assignment01\Assignment01\Views\_ViewImports.cshtml"
using Assignment01;

#line default
#line hidden
#line 2 "E:\Repos\Assignment01\Assignment01\Views\_ViewImports.cshtml"
using Assignment01.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d693a3511b326f7b624d2382553fde73b7e5482b", @"/Views/DanhMuc/TinhThanh/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7c54143f46862f8ba6a2b7cb07772efe59ecd11f", @"/Views/_ViewImports.cshtml")]
    public class Views_DanhMuc_TinhThanh_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "E:\Repos\Assignment01\Assignment01\Views\DanhMuc\TinhThanh\Index.cshtml"
  
    var thongTinNhanVien = ViewData["thongTinNhanVien"] as NhanVien;
    var danhMucTinhThanh = ViewData["DanhMucTinhThanh"] as List<TinhThanh>;
    ViewData["Title"] = "Danh mục tỉnh thành";

#line default
#line hidden
            BeginContext(204, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 8 "E:\Repos\Assignment01\Assignment01\Views\DanhMuc\TinhThanh\Index.cshtml"
  
    Html.RenderPartial("Nav");

#line default
#line hidden
            BeginContext(245, 767, true);
            WriteLiteral(@"
<div id=""page-wrapper"">
    <div class=""row"">
        <div class=""col-lg-12"">
            <h1 class=""page-header"">Danh mục tỉnh thành</h1>
        </div>
    </div>
    <div class=""row"">
        <div class=""col-lg-12"">
            <div class=""panel panel-default"">
                <div class=""panel-body"">
                    <table style=""width: 100%;"" class=""table table-striped table-bordered table-hover"" id=""table_id"">
                        <thead>
                            <tr>
                                <th>Mã tỉnh thành</th>
                                <th>Tỉnh thành</th>
                                <th>Chức năng</th>
                            </tr>
                        </thead>
                        <tbody>
");
            EndContext();
#line 31 "E:\Repos\Assignment01\Assignment01\Views\DanhMuc\TinhThanh\Index.cshtml"
                              
                                foreach (var tt in danhMucTinhThanh)
                                {

#line default
#line hidden
            BeginContext(1149, 86, true);
            WriteLiteral("                                    <tr>\r\n                                        <td>");
            EndContext();
            BeginContext(1236, 9, false);
#line 35 "E:\Repos\Assignment01\Assignment01\Views\DanhMuc\TinhThanh\Index.cshtml"
                                       Write(tt.Idtinh);

#line default
#line hidden
            EndContext();
            BeginContext(1245, 51, true);
            WriteLiteral("</td>\r\n                                        <td>");
            EndContext();
            BeginContext(1297, 10, false);
#line 36 "E:\Repos\Assignment01\Assignment01\Views\DanhMuc\TinhThanh\Index.cshtml"
                                       Write(tt.Tentinh);

#line default
#line hidden
            EndContext();
            BeginContext(1307, 123, true);
            WriteLiteral("</td>\r\n                                        <td>\r\n                                            <a class=\"btn btn-default\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1430, "\"", 1465, 2);
            WriteAttributeValue("", 1437, "/Nhanvien/ChiTiet/", 1437, 18, true);
#line 38 "E:\Repos\Assignment01\Assignment01\Views\DanhMuc\TinhThanh\Index.cshtml"
WriteAttributeValue("", 1455, tt.Idtinh, 1455, 10, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1466, 80, true);
            WriteLiteral(">Sửa</a>\r\n                                            <a class=\"btn btn-default\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1546, "\"", 1582, 2);
            WriteAttributeValue("", 1553, "/Nhanvien/ChiTiet/", 1553, 18, true);
#line 39 "E:\Repos\Assignment01\Assignment01\Views\DanhMuc\TinhThanh\Index.cshtml"
WriteAttributeValue("", 1571, tt.Tentinh, 1571, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1583, 100, true);
            WriteLiteral(">Xóa</a>\r\n                                        </td>\r\n                                    </tr>\r\n");
            EndContext();
#line 42 "E:\Repos\Assignment01\Assignment01\Views\DanhMuc\TinhThanh\Index.cshtml"
                                }
                            

#line default
#line hidden
            BeginContext(1749, 247, true);
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n                </div>\r\n                <!-- /.panel-body -->\r\n            </div>\r\n            <!-- /.panel -->\r\n        </div>\r\n        <!-- /.col-lg-12 -->\r\n    </div>\r\n\r\n</div>\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(2013, 131, true);
                WriteLiteral("\r\n    <script>\r\n        $(document).ready( function () {\r\n            $(\'#table_id\').DataTable();\r\n        });\r\n\r\n    </script>\r\n\r\n");
                EndContext();
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591