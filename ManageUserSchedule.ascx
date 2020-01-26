<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManageUserSchedule.ascx.cs" Inherits="GIBS.Modules.FBEvents.ManageUserSchedule" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.Client.ClientResourceManagement" Assembly="DotNetNuke.Web.Client" %>
<dnn:DnnCssInclude ID="DnnCssInclude1" runat="server" FilePath="~/DesktopModules/GIBS/FBEvents/Css/Style.css" />
<link rel="stylesheet" href="https://ajax.googleapis.com/ajax/libs/jqueryui/1/themes/redmond/jquery-ui.css" />

<script type="text/javascript">

    $(function () {
        $("#txtStartDate").datepicker({
            numberOfMonths: 1,
            minDate: 0,
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
         $("#<%=gv_Report.ClientID%> input[id*='CheckBox1']:checkbox").click(function () {
             //Get number of checkboxes in list either checked or not checked
             var totalCheckboxes = $("#<%=gv_Report.ClientID%> input[id*='CheckBox1']:checkbox").size();
             //Get number of checked checkboxes in list
             var checkedCheckboxes = $("#<%=gv_Report.ClientID%> input[id*='CheckBox1']:checkbox:checked").size();
             //Check / Uncheck top checkbox if all the checked boxes in list are checked
             $("#<%=gv_Report.ClientID%> input[id*='chkAll']:checkbox").attr('checked', totalCheckboxes == checkedCheckboxes);
         });

         $("#<%=gv_Report.ClientID%> input[id*='chkAll']:checkbox").click(function () {
             //Check/uncheck all checkboxes in list according to main checkbox 
             $("#<%=gv_Report.ClientID%> input[id*='CheckBox1']:checkbox").attr('checked', $(this).is(':checked'));
         });


         $("#<%=gv_BulkEnrollShifts.ClientID%> input[id*='CheckBox1']:checkbox").click(function () {
             //Get number of checkboxes in list either checked or not checked
             var totalCheckboxes = $("#<%=gv_BulkEnrollShifts.ClientID%> input[id*='CheckBox1']:checkbox").size();
             //Get number of checked checkboxes in list
             var checkedCheckboxes = $("#<%=gv_BulkEnrollShifts.ClientID%> input[id*='CheckBox1']:checkbox:checked").size();
             //Check / Uncheck top checkbox if all the checked boxes in list are checked
             $("#<%=gv_BulkEnrollShifts.ClientID%> input[id*='chkAll']:checkbox").attr('checked', totalCheckboxes == checkedCheckboxes);
         });

         $("#<%=gv_BulkEnrollShifts.ClientID%> input[id*='chkAll']:checkbox").click(function () {
             //Check/uncheck all checkboxes in list according to main checkbox 
             $("#<%=gv_BulkEnrollShifts.ClientID%> input[id*='CheckBox1']:checkbox").attr('checked', $(this).is(':checked'));
         });

     });
</script>



<div class="dnnForm" id="form-settings">
<h5>
<asp:Label ID="lblWelcomeMsg" runat="server" Text="Label" ResourceKey="lblWelcomeMessage" />
</h5>
    <fieldset>

       
        <div class="dnnFormItem">
            <dnn:label id="lblRolesDropdown" runat="server" suffix=":" controlname="ddlRolesDropdown" ResourceKey="lblRolesDropdown" />
           <asp:dropdownlist id="ddlRolesDropdown" Runat="server" AutoPostBack="True" 
                onselectedindexchanged="ddlRolesDropdown_SelectedIndexChanged"></asp:dropdownlist>
            
        </div>
       
       <div class="dnnFormItem">
            <dnn:label id="lblUserDropdown" runat="server" suffix=":" controlname="ddlUserDropdown" ResourceKey="lblUserDropdown" />
           <asp:dropdownlist id="ddlUserDropdown" Runat="server" AutoPostBack="True" 
                onselectedindexchanged="ddlUserDropdown_SelectedIndexChanged"></asp:dropdownlist>
            
        </div>

        <div id="divVolunteerInfo" runat="server" style="text-align:center; width:100%; padding-bottom:15px;">
            <table class="dnnGrid" style="margin: 0 auto;">
                <tr class="dnnGridHeader">
                    <th>Volunteer Name</th>
                    <th>E-Mail</th>
                    <th>Phone</th>
                    <th>Primary Job</th>
                </tr>
                <tr class="dnnGridItem">
                    <td><asp:Label ID="lblVolunteerName" runat="server" Text=""></asp:Label></td>
                    <td><asp:Label ID="lblVolunteerEmail" runat="server" Text=""></asp:Label></td>
                    <td><asp:Label ID="lblVolunteerPhone" runat="server" Text=""></asp:Label></td>
                    <td><asp:Label ID="lblPrimaryJob" runat="server" Text=""></asp:Label></td>
                </tr>
            </table>

        </div>
		<div>

<asp:GridView ID="gv_Report" runat="server" HorizontalAlign="Center"  
    AutoGenerateColumns="False" CssClass="dnnGrid" OnSorting="gv_Report_Sorting"  
    resourcekey="gv_ReportDetails" DataKeyNames="UserID" EmptyDataText="No Enrollments Found For This Volunteer">
    <HeaderStyle CssClass="dnnGridHeader" />
    <RowStyle CssClass="dnnGridItem" />
<AlternatingRowStyle CssClass="dnnGridAltItem" />    
<PagerStyle CssClass="pgr" />  
<PagerSettings Mode="NumericFirstLast" /> 
    <Columns>

                      <asp:TemplateField Visible="true">

                    <ItemTemplate>
                        <asp:HiddenField ID="hidSignupID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "SignupID") %>' />
                    </ItemTemplate>
                  </asp:TemplateField>          
                            
                            <asp:TemplateField>
                            
<HeaderTemplate>
                <asp:CheckBox runat="server" ID="chkAll" Visible="false" />
            </HeaderTemplate>
                            <ItemTemplate>
                                <center>
                                    <asp:CheckBox ID="CheckBox1" runat="server" Enabled='<%# DataBinder.Eval(Container.DataItem, "PastShift") %>'></asp:CheckBox>
                                </center>
                            </ItemTemplate>
                        </asp:TemplateField>

    <asp:BoundField HeaderText="Shift Name" DataField="ShiftName" SortExpression="ShiftName" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
      <asp:BoundField HeaderText="Day" DataField="ShiftDayOfWeek" SortExpression="Day" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
      
       <asp:BoundField HeaderText="Shift Date" DataField="ShiftDate" SortExpression="ShiftDate" DataFormatString="{0:MM/dd/yyyy}" ItemStyle-HorizontalAlign="Center" ></asp:BoundField>
        <asp:BoundField HeaderText="Start Time" DataField="ShiftStartTime" SortExpression="StartTime" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
		
		<asp:BoundField HeaderText="Hours" DataField="Duration" SortExpression="Duration" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
		<asp:BoundField HeaderText="Volunteer Name" DataField="VolunteerName" SortExpression="VolunteerName" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left" Visible="false"></asp:BoundField>
        <asp:BoundField HeaderText="Primary Job" DataField="PrimaryJob" SortExpression="PrimaryJob" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left" Visible="false"></asp:BoundField>
		<asp:BoundField HeaderText="Email" DataField="VolunteerEmail" SortExpression="Email" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left" Visible="false"></asp:BoundField>
        <asp:BoundField HeaderText="Primary Telephone" DataField="PrimaryTelephone" SortExpression="Telephone" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left" Visible="false"></asp:BoundField>
        <asp:BoundField HeaderText="# Needed" DataField="MaxEnrollment" SortExpression="MaxEnrollment" ItemStyle-VerticalAlign="Top" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center" Visible="false"></asp:BoundField>
        <asp:BoundField HeaderText="Enrolled" DataField="Enrolled" SortExpression="Enrolled" ItemStyle-VerticalAlign="Top" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center" Visible="false"></asp:BoundField>

    </Columns>
</asp:GridView>	        
        
        </div>
        <div class="dnnFormItem" style="text-align:center;">
<asp:LinkButton ID="lbRemoveShift" runat="server" CssClass="dnnSecondaryAction" Visible="false"
                onclick="lbRemoveShift_Click">Remove Selected Shifts</asp:LinkButton>
        </div>
        

        <div class="dnnFormItem">
            <dnn:Label ID="lblStartDate" runat="server" CssClass="dnnFormLabel" AssociatedControlID="txtStartDate" Suffix=":"  />
            <asp:TextBox ID="txtStartDate" runat="server" ClientIDMode="Static" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label ID="lblEndDate" runat="server" CssClass="dnnFormLabel" AssociatedControlID="txtEndDate" Suffix=":" />
            <asp:TextBox ID="txtEndDate" runat="server" ClientIDMode="Static" />
        </div>	


        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lblEventDropdown" ControlName="ddlEventDropdown" ResourceKey="lblEventDropdown" Suffix=":" />
            <asp:dropdownlist id="ddlEventDropdown" Runat="server"></asp:dropdownlist> 
            <asp:Button ID="btnAddShift" runat="server" Text="Add Shift" Visible="false" 
                onclick="btnAddShift_Click" ResourceKey="btnAddShift" />
        </div>	

        <div class="dnnFormItem">
            <dnn:Label runat="server" ID="lblBulkEnrollment" ControlName="ddlEventDropdown" ResourceKey="lblBulkEnrollment" Suffix=":" />
            <asp:dropdownlist id="ddlShiftName" Runat="server" Width="20%"></asp:dropdownlist>
            <asp:dropdownlist id="ddlShiftDay" Runat="server" Width="20%">
                <asp:ListItem Text="-- Day --" Value=""></asp:ListItem>
                <asp:ListItem Text="Monday" Value="Monday"></asp:ListItem>
                <asp:ListItem Text="Tuesday" Value="Tuesday"></asp:ListItem>
                <asp:ListItem Text="Wednesday" Value="Wednesday"></asp:ListItem>
                <asp:ListItem Text="Thursday" Value="Thursday"></asp:ListItem>
                <asp:ListItem Text="Friday" Value="Friday"></asp:ListItem>
                <asp:ListItem Text="Saturday" Value="Saturday"></asp:ListItem>
                <asp:ListItem Text="Sunday" Value="Sunday"></asp:ListItem>
            </asp:dropdownlist>
            <asp:Button ID="btnLoadShifts" runat="server" Text="Add Shift" onclick="btnLoadShifts_Click" ResourceKey="btnLoadShifts" Visible="false" />
        </div>

        <div>
        <asp:GridView ID="gv_BulkEnrollShifts" runat="server" HorizontalAlign="Center"  
    AutoGenerateColumns="False" CssClass="dnnGrid" OnSorting="gv_BulkEnrollShifts_Sorting"  
    DataKeyNames="UserID" EmptyDataText="No Available Shifts">
    <HeaderStyle CssClass="dnnGridHeader" />
    <RowStyle CssClass="dnnGridItem" />
<AlternatingRowStyle CssClass="dnnGridAltItem" />    
<PagerStyle CssClass="pgr" />  
<PagerSettings Mode="NumericFirstLast" /> 
    <Columns>           
    <asp:TemplateField ItemStyle-HorizontalAlign="Center">                     
        <HeaderTemplate>
            <asp:CheckBox runat="server" ID="chkAll" />
        </HeaderTemplate>
        <ItemTemplate>
                <asp:CheckBox ID="CheckBox1" runat="server"></asp:CheckBox><asp:HiddenField ID="hidEventID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "EventID") %>' />
        </ItemTemplate>
    </asp:TemplateField>

    <asp:BoundField HeaderText="Shift Name" DataField="ShiftName" SortExpression="ShiftName" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
      <asp:BoundField HeaderText="Day" DataField="ShiftDayOfWeek" SortExpression="Day" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
      
       <asp:BoundField HeaderText="Shift Date" DataField="ShiftDate" SortExpression="ShiftDate" DataFormatString="{0:MM/dd/yyyy}" ItemStyle-HorizontalAlign="Center" ></asp:BoundField>
        <asp:BoundField HeaderText="Start Time" DataField="ShiftStartTime" SortExpression="StartTime" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
		
		<asp:BoundField HeaderText="Hours" DataField="Duration" SortExpression="Duration" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
		<asp:BoundField HeaderText="#Needed" DataField="MaxEnrollment" SortExpression="MaxEnrollment" ItemStyle-VerticalAlign="Top" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
        <asp:BoundField HeaderText="Enrolled" DataField="Enrolled" SortExpression="Enrolled" ItemStyle-VerticalAlign="Top" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>

    </Columns>
</asp:GridView>	  
        
        </div>



        <div class="dnnFormItem" style="text-align:center;">
<asp:LinkButton ID="lbAddBulkShift" runat="server" CssClass="dnnSecondaryAction"  Visible="false" 
                onclick="lbAddBulkShift_Click">Add Selected Shifts</asp:LinkButton>
        </div>


    </fieldset>

 </div>