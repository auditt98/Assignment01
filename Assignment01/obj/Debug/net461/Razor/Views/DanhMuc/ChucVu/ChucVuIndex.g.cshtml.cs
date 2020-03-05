#pragma checksum "E:\Repos\Assignment01\Assignment01\Views\DanhMuc\ChucVu\ChucVuIndex.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "33f4bcd34277f8fc60570c7f6cf4a5bf5adfdf01"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_DanhMuc_ChucVu_ChucVuIndex), @"mvc.1.0.view", @"/Views/DanhMuc/ChucVu/ChucVuIndex.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/DanhMuc/ChucVu/ChucVuIndex.cshtml", typeof(AspNetCore.Views_DanhMuc_ChucVu_ChucVuIndex))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"33f4bcd34277f8fc60570c7f6cf4a5bf5adfdf01", @"/Views/DanhMuc/ChucVu/ChucVuIndex.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7c54143f46862f8ba6a2b7cb07772efe59ecd11f", @"/Views/_ViewImports.cshtml")]
    public class Views_DanhMuc_ChucVu_ChucVuIndex : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "E:\Repos\Assignment01\Assignment01\Views\DanhMuc\ChucVu\ChucVuIndex.cshtml"
  
    var thongTinNhanVien = ViewData["thongTinNhanVien"] as NhanVien;
    var danhSachChucVu = ViewData["DanhSachChucVu"] as List<ChucVu>;
    ViewData["Title"] = "Nhân viên cùng phòng";

#line default
#line hidden
            BeginContext(198, 29, true);
            WriteLiteral("<script>\r\n\r\n\r\n\r\n</script>\r\n\r\n");
            EndContext();
#line 13 "E:\Repos\Assignment01\Assignment01\Views\DanhMuc\ChucVu\ChucVuIndex.cshtml"
  
    Html.RenderPartial("Nav");

#line default
#line hidden
            BeginContext(266, 758, true);
            WriteLiteral(@"
<div id=""page-wrapper"">
    <div class=""row"">
        <div class=""col-lg-12"">
            <h1 class=""page-header"">Danh mục chức vụ</h1>
        </div>
    </div>
    <div class=""row"">
        <div class=""col-lg-12"">
            <div class=""panel panel-default"">
                <div class=""panel-body"">
                    <table style=""width: 100%;"" class=""table table-striped table-bordered table-hover"" id=""table_id"">
                        <thead>
                            <tr>
                                <th>Mã chức vụ</th>
                                <th>Chức vụ</th>
                                <th>Chức năng</th>
                            </tr>
                        </thead>
                        <tbody>
");
            EndContext();
#line 36 "E:\Repos\Assignment01\Assignment01\Views\DanhMuc\ChucVu\ChucVuIndex.cshtml"
                              
                                foreach (var cv in danhSachChucVu)
                                {

#line default
#line hidden
            BeginContext(1159, 86, true);
            WriteLiteral("                                    <tr>\r\n                                        <td>");
            EndContext();
            BeginContext(1246, 7, false);
#line 40 "E:\Repos\Assignment01\Assignment01\Views\DanhMuc\ChucVu\ChucVuIndex.cshtml"
                                       Write(cv.Idcv);

#line default
#line hidden
            EndContext();
            BeginContext(1253, 51, true);
            WriteLiteral("</td>\r\n                                        <td>");
            EndContext();
            BeginContext(1305, 8, false);
#line 41 "E:\Repos\Assignment01\Assignment01\Views\DanhMuc\ChucVu\ChucVuIndex.cshtml"
                                       Write(cv.Tencv);

#line default
#line hidden
            EndContext();
            BeginContext(1313, 123, true);
            WriteLiteral("</td>\r\n                                        <td>\r\n                                            <a class=\"btn btn-default\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1436, "\"", 1469, 2);
            WriteAttributeValue("", 1443, "/Nhanvien/ChiTiet/", 1443, 18, true);
#line 43 "E:\Repos\Assignment01\Assignment01\Views\DanhMuc\ChucVu\ChucVuIndex.cshtml"
WriteAttributeValue("", 1461, cv.Idcv, 1461, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1470, 80, true);
            WriteLiteral(">Sửa</a>\r\n                                            <a class=\"btn btn-default\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1550, "\"", 1583, 2);
            WriteAttributeValue("", 1557, "/Nhanvien/ChiTiet/", 1557, 18, true);
#line 44 "E:\Repos\Assignment01\Assignment01\Views\DanhMuc\ChucVu\ChucVuIndex.cshtml"
WriteAttributeValue("", 1575, cv.Idcv, 1575, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1584, 100, true);
            WriteLiteral(">Xóa</a>\r\n                                        </td>\r\n                                    </tr>\r\n");
            EndContext();
#line 47 "E:\Repos\Assignment01\Assignment01\Views\DanhMuc\ChucVu\ChucVuIndex.cshtml"
                                }
                            

#line default
#line hidden
            BeginContext(1750, 247, true);
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n                </div>\r\n                <!-- /.panel-body -->\r\n            </div>\r\n            <!-- /.panel -->\r\n        </div>\r\n        <!-- /.col-lg-12 -->\r\n    </div>\r\n\r\n</div>\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(2014, 131, true);
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