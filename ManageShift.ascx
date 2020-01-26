<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManageShift.ascx.cs" Inherits="GIBS.Modules.FBEvents.ManageShift" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.Client.ClientResourceManagement" Assembly="DotNetNuke.Web.Client" %>
<dnn:DnnCssInclude ID="DnnCssInclude1" runat="server" FilePath="~/DesktopModules/GIBS/FBEvents/Css/Style.css" />
<link rel="stylesheet" href="https://ajax.googleapis.com/ajax/libs/jqueryui/1/themes/redmond/jquery-ui.css" />

<script type="text/javascript">

    $(function () {
        $("#txtStartDate").datepicker({
            numberOfMonths: 1,
            showButtonPanel: false,
            showCurrentAtPos: 0
        });
        $("#txtEndDate").datepicker({
            showButtonPanel: false
        });
    });

 </script>


 
<script type="text/javascript">
    $(document).ready(function () {
        $("#<%=gv_EventSchedule.ClientID%> input[id*='CheckBox1']:checkbox").click(function () {
            //Get number of checkboxes in list either checked or not checked
            var totalCheckboxes = $("#<%=gv_EventSchedule.ClientID%> input[id*='CheckBox1']:checkbox").size();
            //Get number of checked checkboxes in list
            var checkedCheckboxes = $("#<%=gv_EventSchedule.ClientID%> input[id*='CheckBox1']:checkbox:checked").size();
            //Check / Uncheck top checkbox if all the checked boxes in list are checked
            $("#<%=gv_EventSchedule.ClientID%> input[id*='chkAll']:checkbox").attr('checked', totalCheckboxes == checkedCheckboxes);
        });

        $("#<%=gv_EventSchedule.ClientID%> input[id*='chkAll']:checkbox").click(function () {
            //Check/uncheck all checkboxes in list according to main checkbox 
            $("#<%=gv_EventSchedule.ClientID%> input[id*='CheckBox1']:checkbox").attr('checked', $(this).is(':checked'));
        });
    });
</script>





<div class="dnnForm" id="form-settings">

    <fieldset>

       
        <div class="dnnFormItem">
            <dnn:label id="lblRolesDropdown" runat="server" suffix=":" controlname="ddlRolesDropdown" ResourceKey="lblRolesDropdown" Visible="false" />
           <asp:dropdownlist id="ddlRolesDropdown" Runat="server" AutoPostBack="True" Visible="false"
                onselectedindexchanged="ddlRolesDropdown_SelectedIndexChanged"></asp:dropdownlist>
            
        </div>
       
       <div class="dnnFormItem">
            <dnn:label id="lblUserDropdown" runat="server" suffix=":" controlname="ddlUserDropdown" ResourceKey="lblUserDropdown" Visible="false" />
           <asp:dropdownlist id="ddlUserDropdown" Runat="server" AutoPostBack="True" Visible="false" 
                onselectedindexchanged="ddlUserDropdown_SelectedIndexChanged"></asp:dropdownlist>
            <asp:Button ID="btnAddShift" runat="server" Text="Add Shift" Visible="false" 
                onclick="btnAddShift_Click" />
        </div>

		<div>

<asp:GridView ID="gv_Report" runat="server" HorizontalAlign="Center"  
    AutoGenerateColumns="False" CssClass="dnnGrid" OnSorting="gv_Report_Sorting"  
    resourcekey="gv_ReportDetails" EnableViewState="False" DataKeyNames="UserID" EmptyDataText="No Enrollments Found For This Volunteer">
    <HeaderStyle CssClass="dnnGridHeader" />
    <RowStyle CssClass="dnnGridItem" />
<AlternatingRowStyle CssClass="dnnGridAltItem" />    
<PagerStyle CssClass="pgr" />  
<PagerSettings Mode="NumericFirstLast" /> 
    <Columns>
    <asp:BoundField HeaderText="Shift Name" DataField="ShiftName" SortExpression="ShiftName" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
      <asp:BoundField HeaderText="Day" DataField="ShiftDayOfWeek" SortExpression="Day" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
      
       <asp:BoundField HeaderText="Shift Date" DataField="ShiftDate" SortExpression="ShiftDate" DataFormatString="{0:MM/dd/yyyy}" ItemStyle-HorizontalAlign="Center" ></asp:BoundField>
        <asp:BoundField HeaderText="Start Time" DataField="ShiftStartTime" SortExpression="StartTime" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
		
		<asp:BoundField HeaderText="Hours" DataField="Duration" SortExpression="Duration" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
		<asp:BoundField HeaderText="Volunteer Name" DataField="VolunteerName" SortExpression="VolunteerName" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
        <asp:BoundField HeaderText="Job" DataField="PrimaryJob" SortExpression="PrimaryJob" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
		<asp:BoundField HeaderText="Email" DataField="VolunteerEmail" SortExpression="Email" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left" ></asp:BoundField>
        <asp:BoundField HeaderText="Primary Telephone" DataField="PrimaryTelephone" SortExpression="Telephone" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
        <asp:BoundField HeaderText="# Needed" DataField="MaxEnrollment" SortExpression="MaxEnrollment" ItemStyle-VerticalAlign="Top" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center" Visible="false"></asp:BoundField>
        <asp:BoundField HeaderText="Enrolled" DataField="Enrolled" SortExpression="Enrolled" ItemStyle-VerticalAlign="Top" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center" Visible="false"></asp:BoundField>

    </Columns>
</asp:GridView>	        
        
        </div>



        <div class="dnnFormItem">
            <dnn:Label ID="lblStartDate" runat="server" CssClass="dnnFormLabel" AssociatedControlID="txtStartDate" Suffix=":" />
            <asp:TextBox ID="txtStartDate" runat="server" ClientIDMode="Static" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label ID="lblEndDate" runat="server" CssClass="dnnFormLabel" AssociatedControlID="txtEndDate" Suffix=":" />
            <asp:TextBox ID="txtEndDate" runat="server" ClientIDMode="Static" />
            <asp:Button ID="btnRefreshShifts" CssClass="dnnSecondaryAction"
                runat="server" Text="Refresh List" onclick="btnRefreshShifts_Click" meta:resourcekey="btnRefreshShifts" />
        </div>	


        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lblEventDropdown" ControlName="ddlEventDropdown" ResourceKey="lblEventDropdown" Suffix=":" />
            <asp:dropdownlist id="ddlEventDropdown" Runat="server" AutoPostBack="True" 
                onselectedindexchanged="ddlEventDropdown_SelectedIndexChanged"></asp:dropdownlist>
        </div>	
        <div class="dnnFormMessage dnnFormSuccess" ID="lblErrorDiv" runat="server" visible="false">
            <asp:Label ID="lblError" runat="server" />
        </div>

		<div>

<asp:GridView ID="gv_EventSchedule" runat="server" HorizontalAlign="Center"  
    AutoGenerateColumns="False" CssClass="dnnGrid" OnSorting="gv_EventSchedule_Sorting"  
    resourcekey="gv_EventScheduleDetails" EnableViewState="True" DataKeyNames="UserID" EmptyDataText="No Enrollments Found For This Shift">
    <HeaderStyle CssClass="dnnGridHeader" />
    <RowStyle CssClass="dnnGridItem" />
<AlternatingRowStyle CssClass="dnnGridAltItem" />    
<PagerStyle CssClass="pgr" />  
<PagerSettings Mode="NumericFirstLast" /> 
    <Columns>
  
 
                  <asp:TemplateField Visible="true">

                    <ItemTemplate>
                        <asp:HiddenField ID="hidUserID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "UserID") %>' />
                    </ItemTemplate>
                  </asp:TemplateField>          
                            
                            <asp:TemplateField>
                            
<HeaderTemplate>
                <asp:CheckBox runat="server" ID="chkAll" />
            </HeaderTemplate>
                            <ItemTemplate>
                                <center>
                                    <asp:CheckBox ID="CheckBox1" runat="server"></asp:CheckBox>
                                </center>
                            </ItemTemplate>
                        </asp:TemplateField>

    <asp:BoundField HeaderText="Shift Name" DataField="ShiftName" SortExpression="ShiftName" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left" Visible="false"></asp:BoundField>
      <asp:BoundField HeaderText="Day" DataField="ShiftDayOfWeek" SortExpression="Day" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center" Visible="false"></asp:BoundField>
      
       <asp:BoundField HeaderText="Shift Date" DataField="ShiftDate" SortExpression="ShiftDate" DataFormatString="{0:MM/dd/yyyy}" ItemStyle-HorizontalAlign="Center" Visible="false"></asp:BoundField>
        <asp:BoundField HeaderText="Start Time" DataField="ShiftStartTime" SortExpression="StartTime" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center" Visible="false"></asp:BoundField>
		
		<asp:BoundField HeaderText="Hours" DataField="Duration" SortExpression="Duration" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center" Visible="false"></asp:BoundField>
		<asp:BoundField HeaderText="Volunteer Name" DataField="VolunteerName" SortExpression="VolunteerName" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
        <asp:BoundField HeaderText="Job" DataField="PrimaryJob" SortExpression="PrimaryJob" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left"></asp:BoundField>

        <asp:TemplateField Visible="false">
            <HeaderTemplate>E-Mail Address
            </HeaderTemplate>
            <ItemTemplate>
                <center>
                    <asp:TextBox name="UserEmail" ID="UserEmail" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "VolunteerEmail") %>'
                        CssClass="SmallInputs">
                    </asp:TextBox></center>
            </ItemTemplate>
        </asp:TemplateField>

		<asp:BoundField HeaderText="Email" DataField="VolunteerEmail" SortExpression="Email" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left" Visible="true" ></asp:BoundField>
        <asp:BoundField HeaderText="Primary Telephone" DataField="PrimaryTelephone" SortExpression="Telephone" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
        <asp:BoundField HeaderText="# Needed" DataField="MaxEnrollment" SortExpression="MaxEnrollment" ItemStyle-VerticalAlign="Top" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center" Visible="false"></asp:BoundField>
        <asp:BoundField HeaderText="Enrolled" DataField="Enrolled" SortExpression="Enrolled" ItemStyle-VerticalAlign="Top" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center" Visible="false"></asp:BoundField>

    </Columns>
</asp:GridView>	        
        
        </div>
        
        <div class="dnnFormItem"><dnn:Label runat="server" ID="lblSubject" ControlName="txtSubject" ResourceKey="lblSubject" Suffix=":" />
<asp:TextBox ID="txtSubject" runat="server" />
        </div>
        
        <div class="dnnFormItem"><dnn:Label runat="server" ID="lblMessage" ControlName="txtMessage" ResourceKey="lblMessage" Suffix=":" />
<asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" />
            <asp:Button ID="btnSendMessage" runat="server" Text="Send Message" CssClass="dnnPrimaryAction" 
                onclick="btnSendMessage_Click" meta:resourcekey="btnSendMessage" />

        </div>



    </fieldset>

 </div>