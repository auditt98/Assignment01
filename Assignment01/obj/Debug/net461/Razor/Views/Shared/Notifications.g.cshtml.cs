#pragma checksum "E:\Repos\Assignment01\Assignment01\Views\Shared\Notifications.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "27063dcab1934142c8217818986a9ad5ebae310d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Notifications), @"mvc.1.0.view", @"/Views/Shared/Notifications.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Notifications.cshtml", typeof(AspNetCore.Views_Shared_Notifications))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"27063dcab1934142c8217818986a9ad5ebae310d", @"/Views/Shared/Notifications.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7c54143f46862f8ba6a2b7cb07772efe59ecd11f", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Notifications : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 3 "E:\Repos\Assignment01\Assignment01\Views\Shared\Notifications.cshtml"
  
    var successMessage = TempData["Success"];
    var errorMessage = TempData["Error"];

#line default
#line hidden
            BeginContext(101, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 8 "E:\Repos\Assignment01\Assignment01\Views\Shared\Notifications.cshtml"
 if (successMessage != null)
{

#line default
#line hidden
            BeginContext(136, 167, true);
            WriteLiteral("    <div class=\"alert alert-success alert-dismissable\">\r\n        <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>\r\n        ");
            EndContext();
            BeginContext(304, 14, false);
#line 12 "E:\Repos\Assignment01\Assignment01\Views\Shared\Notifications.cshtml"
   Write(successMessage);

#line default
#line hidden
            EndContext();
            BeginContext(318, 14, true);
            WriteLiteral("\r\n    </div>\r\n");
            EndContext();
#line 14 "E:\Repos\Assignment01\Assignment01\Views\Shared\Notifications.cshtml"
}

#line default
#line hidden
            BeginContext(335, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 16 "E:\Repos\Assignment01\Assignment01\Views\Shared\Notifications.cshtml"
 if (errorMessage != null)
{

#line default
#line hidden
            BeginContext(368, 166, true);
            WriteLiteral("    <div class=\"alert alert-danger alert-dismissable\">\r\n        <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>\r\n        ");
            EndContext();
            BeginContext(535, 12, false);
#line 20 "E:\Repos\Assignment01\Assignment01\Views\Shared\Notifications.cshtml"
   Write(errorMessage);

#line default
#line hidden
            EndContext();
            BeginContext(547, 14, true);
            WriteLiteral("\r\n    </div>\r\n");
            EndContext();
#line 22 "E:\Repos\Assignment01\Assignment01\Views\Shared\Notifications.cshtml"
}

#line default
#line hidden
            BeginContext(564, 6, true);
            WriteLiteral("\r\n\r\n\r\n");
            EndContext();
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
