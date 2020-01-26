<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Settings.ascx.cs" Inherits="GIBS.Modules.FBEvents.Settings" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="SectionHead" Src="~/controls/SectionHeadControl.ascx" %>


<div class="dnnForm" id="form-settings">


    <fieldset>

<dnn:sectionhead id="sectGeneralSettings" cssclass="Head" runat="server" text="General Settings" section="GeneralSection"
	includerule="False" isexpanded="True"></dnn:sectionhead>

<div id="GeneralSection" runat="server">   


             
                    
                    		


		<div class="dnnFormItem">					
            <dnn:label id="lblEventsModuleID" runat="server" suffix=":" controlname="drpModuleID" ResourceKey="lblEventsModuleID" />
			<asp:dropdownlist id="drpModuleID" Runat="server" datavaluefield="ModuleID" datatextfield="ModuleTitle"
				CssClass="NormalTextBox" AutoPostBack="True"></asp:dropdownlist>
         </div>	
        

        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lblRoleGroupID" ControlName="txtRoleGroupID" ResourceKey="lblRoleGroupID" Suffix=":" />
            <asp:Textbox ID="txtRoleGroupID" runat="server" />
        </div>			


        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lblProfileCheck" ControlName="txtProfileCheck" ResourceKey="lblProfileCheck" Suffix=":" />
            <asp:Textbox ID="txtProfileCheck" runat="server" ReadOnly="true" />
           
        </div>	
    

</div>  

   





    </fieldset>

 </div>