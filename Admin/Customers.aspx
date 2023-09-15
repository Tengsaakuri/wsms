<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="WSMS.Admin.Customers" %>

<asp:Content ID="Content2" ContentPlaceHolderID="header" runat="server">
    <div class="row align-items-end">
        <div class="col-lg-8">
            <div class="page-header-title">
                <i class="feather icon-user-plus bg-c-blue"></i>
                <div class="d-inline">
                    <h5>Customer Registration</h5>
                    <span>Input the details of a new Customer</span>
                </div>
            </div>
        </div>
        <div class="col-lg-4">
            <div class="page-header-breadcrumb">
                <ul class=" breadcrumb breadcrumb-title">
                    <li class="breadcrumb-item">
                        <a href="dashboard.aspx"><i class="icon-home"></i></a>
                    </li>
                    <li class="breadcrumb-item"><a href="#!">Customer</a>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div class="card">
                <div class="card-header">
                    <h5>Customer Information</h5>
                </div>
                
                    
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-12 col-sm-12">
                            <div class="alert alert-success alert-dismissible mb-2" role="alert" runat="server" id="success_msg">
                                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                                <b>Success!</b>
                                <asp:Label ID="success_Label" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-12 col-sm-12">
                            <div class="alert alert-danger alert-dismissible mb-2" role="alert" runat="server" id="error_msg">
                                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                                <b>Stop!</b>
                                <asp:Label ID="error_Label" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 col-sm-12">
                            <div class="input-group">
                                <span class="input-group-prepend">
                                    <label class="input-group-text"><i class="icon-paper-clip"></i></label>
                                </span>
                                <asp:Label ID="txt_ID" runat="server" ClientIDMode="Static"
                                    class="form-control" ReadOnly="true" placeholder="Id"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 col-sm-12">
                            <div class="input-group">
                                <span class="input-group-prepend">
                                    <label class="input-group-text"><i class="icon-user"></i></label>
                                </span>
                                <asp:TextBox ID="txt_First" runat="server" ClientIDMode="Static"
                                    class="form-control" placeholder="First name"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12">
                            <div class="input-group">
                                <span class="input-group-prepend">
                                    <label class="input-group-text"><i class="icon-user"></i></label>
                                </span>
                                <asp:TextBox ID="txt_Last" runat="server" ClientIDMode="Static"
                                    class="form-control" placeholder="Last name"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 col-sm-12">
                            <div class="input-group">
                                <span class="input-group-prepend">
                                    <label class="input-group-text"><i class="icon-people"></i></label>
                                </span>
                                <asp:DropDownList ID="cmb_Gender" runat="server" CssClass="form-control">
                                    <asp:ListItem>- Select gender -</asp:ListItem>
                                    <asp:ListItem>Male</asp:ListItem>
                                    <asp:ListItem>Female</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12">
                            <div class="input-group">
                                <span class="input-group-prepend">
                                    <label class="input-group-text"><i class="icon-calendar"></i></label>
                                </span>
                                <asp:TextBox ID="txt_DOD" runat="server" ClientIDMode="Static"
                                    class="form-control" TextMode="Date" placeholder="Date of Birth"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 col-sm-12">
                            <div class="input-group">
                                <span class="input-group-prepend">
                                    <label class="input-group-text"><i class="icon-phone"></i></label>
                                </span>
                                <asp:TextBox ID="txt_Number" runat="server" ClientIDMode="Static"
                                    class="form-control" TextMode="Phone" placeholder="Phone number"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12">
                            <div class="input-group">
                                <span class="input-group-prepend">
                                    <label class="input-group-text"><i class="icon-location-pin"></i></label>
                                </span>
                                <asp:TextBox ID="txt_Address" runat="server" ClientIDMode="Static"
                                    class="form-control" placeholder="Address"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                    <div class="row">
                        <div class="col-md-6 col-sm-12">
                            <div class="input-group">
                                <span class="input-group-prepend">
                                    <label class="input-group-text"><i class="icon-pin"></i></label>
                                </span>
                                <asp:TextBox ID="txt_House_Number" runat="server" ClientIDMode="Static"
                                    class="form-control" placeholder="House number"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3 col-sm-12">
                            <div class="input-group">
                                <span class="input-group-prepend">
                                    <label class="input-group-text"><i class="icon-layers"></i></label>
                                </span>
                                <asp:DropDownList ID="ddl_Meter" runat="server" CssClass="form-control" AutoPostBack="true"
                                   OnSelectedIndexChanged="cmb_Meter_SelectedIndexChanged" AppendDataBoundItems="true">
                                    <asp:ListItem>- Select meter -</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3 col-sm-12">
                            <asp:Label ID="txt_Category" runat="server" ClientIDMode="Static"
                                    class="form-control" placeholder="Meter Category"></asp:Label>
                        </div>

                    </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddl_Meter" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
                    <div class="row">
                        <div class="col-md-6 col-sm-12">
                            <asp:Button ID="btn_Save" runat="server" class="btn btn-primary btn-block" Text="Save"
                                OnClick="btn_Save_Click"/>
                        </div>
                        <%--<div class="col-md-6 col-sm-12">
                            
                        </div>--%>
                    </div>
                    <%--<div class="modal-footer">
                       
                   </div>--%>
                    <hr />
                    <div class="table-responsive">
                        <asp:Repeater ID="repeat" runat="server">
                            <HeaderTemplate>
                                <table id="order-table" class="table table-bordered table-hover">
                                    <thead class="text-uppercase">
                                        <tr>
                                            <th scope="col">ID </th>
                                            <th scope="col">Name </th>
                                            <th scope="col">Gender</th>
                                            <th scope="col">Phone</th>
                                            <th scope="col">House Number</th>
                                            <th scope="col">Meter</th>
                                            <th scope="col">Action</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Label ID="Id_Label" runat="server" Text='<%#Eval("Customer_Id") %>'></asp:Label></td>
                                    <td><%#Eval("First_Name") %> <%#Eval("Last_Name") %></td>
                                    <td><%#Eval("Gender") %></td>
                                    <td><%#Eval("Phone_Number") %></td>
                                    <td><%#Eval("Hse_Number") %></td>
                                    <td><%#Eval("Meter") %></td>
                                    <td>
                                        <div class="btn-group" role="group" aria-label="Basic mixed styles example">
                                            <asp:LinkButton ID="edit" runat="server" OnClick="edit_Click" 
                                                 CssClass="btn btn-outline-info btn-sm" > 
                                            <span class="fa fa-edit"></span> </asp:LinkButton>
                                            <asp:LinkButton ID="delete" runat="server" OnClick="delete_Click"
                                                 CssClass="btn btn-outline-danger btn-sm">
                                            <span class="fa fa-trash"></span> </asp:LinkButton>
                                        </div>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tbody>
                          </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>

