#pragma checksum "C:\Users\taras\RiderProjects\TeamFinder\TeamFinderPL\Views\BoardGame\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0f2a1608f8987fa515f4ece9962216d28bbb3f79"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_BoardGame_Index), @"mvc.1.0.view", @"/Views/BoardGame/Index.cshtml")]
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
#line 1 "C:\Users\taras\RiderProjects\TeamFinder\TeamFinderPL\Views\_ViewImports.cshtml"
using TeamFinder;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\taras\RiderProjects\TeamFinder\TeamFinderPL\Views\_ViewImports.cshtml"
using TeamFinder.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0f2a1608f8987fa515f4ece9962216d28bbb3f79", @"/Views/BoardGame/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ab3ade49f346e259b1c4a4aa60dfe0657359370e", @"/Views/_ViewImports.cshtml")]
    public class Views_BoardGame_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<TeamFinderDAL.Entities.BoardGame>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "BoardGame", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"container p-3\">\r\n    <div class=\"row pt-4\">\r\n        <div class=\"col-6\">\r\n            <h2 class=\"text-primary\">Board Games</h2>\r\n        </div>\r\n        <div class=\"col-6 text-right\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0f2a1608f8987fa515f4ece9962216d28bbb3f794316", async() => {
                WriteLiteral("Add Board Game");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    \r\n");
#nullable restore
#line 13 "C:\Users\taras\RiderProjects\TeamFinder\TeamFinderPL\Views\BoardGame\Index.cshtml"
     if (Model.Any())
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <table class=\"table table-bordered table-striped\" style=\"width:100%\">\r\n            <thead>\r\n            <tr>\r\n                <th>Name</th>\r\n                <th>Difficulty</th>\r\n");
            WriteLiteral("            </tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 24 "C:\Users\taras\RiderProjects\TeamFinder\TeamFinderPL\Views\BoardGame\Index.cshtml"
             foreach (var bGame in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td width=\"50%\">");
#nullable restore
#line 27 "C:\Users\taras\RiderProjects\TeamFinder\TeamFinderPL\Views\BoardGame\Index.cshtml"
                               Write(bGame.BGameName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td width=\"50%\">");
#nullable restore
#line 28 "C:\Users\taras\RiderProjects\TeamFinder\TeamFinderPL\Views\BoardGame\Index.cshtml"
                               Write(bGame.Difficulty);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 30 "C:\Users\taras\RiderProjects\TeamFinder\TeamFinderPL\Views\BoardGame\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n");
#nullable restore
#line 33 "C:\Users\taras\RiderProjects\TeamFinder\TeamFinderPL\Views\BoardGame\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<TeamFinderDAL.Entities.BoardGame>> Html { get; private set; }
    }
}
#pragma warning restore 1591
