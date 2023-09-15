<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="WSMS.Admin.Payment" %>

<asp:Content ID="Content2" ContentPlaceHolderID="header" runat="server">
    <div class="row align-items-end">
        <div class="col-lg-8">
            <div class="page-header-title">
                <i class="fa fa-money-bill-alt bg-c-blue"></i>
                <div class="d-inline">
                    <h5>Bill Payment</h5>
                    <span>Input the details of a receive customer payment</span>
                </div>
            </div>
        </div>
        <div class="col-lg-4">
            <div class="page-header-breadcrumb">
                <ul class=" breadcrumb breadcrumb-title">
                    <li class="breadcrumb-item">
                        <a href="dashboard.aspx"><i class="icon-home"></i></a>
                    </li>
                    <li class="breadcrumb-item"><a href="#!">Bill Payment</a>
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
                    <h5>Customer Details</h5>
                </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-12 col-sm-12">
                            <div class="alert alert-danger alert-dismissible mb-2" role="alert" runat="server" id="error_msg">
                                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                                <strong>Stop!</strong>
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
                                <asp:DropDownList ID="ddl_IDs" runat="server" AutoPostBack="true"
                                   AppendDataBoundItems="true" CssClass="form-control"
                                    OnSelectedIndexChanged="ddl_IDs_SelectedIndexChanged">
                                    <asp:ListItem>- Select Customer -</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-8 col-sm-12">
                            <div class="input-group">
                                <span class="input-group-prepend">
                                    <label class="input-group-text"><i class="icon-user"></i></label>
                                </span>
                                <asp:Label ID="txt_Name" runat="server" ClientIDMode="Static"
                                    class="form-control" Text="Full name"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-4 col-sm-12">
                            <div class="input-group">
                                <span class="input-group-prepend">
                                    <label class="input-group-text"><i class="icon-user"></i></label>
                                </span>
                                <asp:Label ID="txt_Gender" runat="server" ClientIDMode="Static"
                                    class="form-control" Text="Gender"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4 col-sm-12">
                            <div class="input-group">
                                <span class="input-group-prepend">
                                    <label class="input-group-text"><i class="icon-phone"></i></label>
                                </span>
                                <asp:Label ID="txt_Number" runat="server" ClientIDMode="Static"
                                    class="form-control" Text="Phone number"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-4 col-sm-12">
                            <div class="input-group">
                                <span class="input-group-prepend">
                                    <label class="input-group-text"><i class="icon-location-pin"></i></label>
                                </span>
                                <asp:Label ID="txt_Address" runat="server" ClientIDMode="Static"
                                    class="form-control" Text="Address"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-4 col-sm-12">
                            <div class="input-group">
                                <span class="input-group-prepend">
                                    <label class="input-group-text"><i class="icon-pin"></i></label>
                                </span>
                                <asp:Label ID="txt_House_Number" runat="server" ClientIDMode="Static"
                                    class="form-control" Text="Hse number"></asp:Label>
                            </div>
                        </div>
                    </div>

                </div>
                
                <div class="row">
                    <div class="col-md-5 col-sm-12">
                        <div class="card-header">
                    <h5>Meter Details</h5>
                </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-12 col-sm-12">
                                    <div class="input-group">
                                        <span class="input-group-prepend">
                                            <label class="input-group-text"><i class="icon-paper-clip"></i></label>
                                        </span>
                                        <asp:DropDownList ID="ddl_Meters" runat="server" CssClass="form-control" AutoPostBack="true"
                                            AppendDataBoundItems="true" OnSelectedIndexChanged="ddl_Meters_SelectedIndexChanged">
                                            <asp:ListItem>- Select meter -</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12 col-sm-12">
                                    <div class="input-group">
                                        <span class="input-group-prepend">
                                            <asp:Label ID="Label6" runat="server" Text="GH₵"
                                               Font-Size="Small" class="input-group-text"></asp:Label>
                                        </span>
                                        <asp:Label ID="txt_Charge" runat="server" ClientIDMode="Static"
                                            class="form-control" Text="0">
                                        </asp:Label>
                                        <span class="input-group-append">
                                            <asp:Label ID="Label1" runat="server" Text="Unit charge"
                                               Font-Size="Small" class="input-group-text"></asp:Label>
                                        </span>
                                        
                                    </div>
                                    
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12 col-sm-12">
                                    <div class="input-group">
                                        <span class="input-group-prepend">
                                            <label class="input-group-text"><i class="icon-layers"></i></label>
                                        </span>
                                        <asp:Label ID="txt_Category" runat="server" ClientIDMode="Static"
                                            class="form-control" Text="Category"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12 col-sm-12">
                                    <div class="input-group">
                                        <span class="input-group-prepend">
                                            <asp:Label ID="Label4" runat="server" Text="GH₵"
                                               Font-Size="Small" class="input-group-text"></asp:Label>
                                        </span>
                                        <asp:Label ID="txt_Balance" runat="server" ClientIDMode="Static"
                                            class="form-control" Text="0"></asp:Label>
                                        
                                        <span class="input-group-append">
                                            <asp:Label ID="Label3" runat="server" Text="Arrears"
                                               Font-Size="Small" class="input-group-text"></asp:Label>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-7 col-sm-12">
                        <div class="card-header">
                    <h5>Payment Details</h5>
                </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-6 col-sm-12">
                                    <div class="input-group">

                                        <asp:TextBox ID="txt_Consumption" runat="server" ClientIDMode="Static"
                                            class="form-control" placeholder="Consumption"></asp:TextBox>
                                        <span class="input-group-prepend">
                                            <button id="btn_Calculate" runat="server" onserverclick="btn_Calculate_ServerClick">
                                                <i class="icon-calculator"></i></button>
                                        </span>
                                    </div>
                                </div>
                                <div class="col-md-6 col-sm-12">
                                    <div class="input-group">
                                        <span class="input-group-prepend">
                                            <asp:Label ID="Label2" runat="server" Text="GH₵"
                                               Font-Size="Small" class="input-group-text"></asp:Label>
                                        </span>
                                        <asp:Label ID="txt_Total" runat="server" ClientIDMode="Static"
                                            class="form-control" Text="0"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 col-sm-12">
                                    <div class="input-group">
                                        <span class="input-group-prepend">
                                            <label class="input-group-text"><i class="icon-calendar"></i></label>
                                        </span>
                                        <asp:DropDownList ID="ddl_Months" runat="server" CssClass="form-control"
                                            AppendDataBoundItems="true">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-6 col-sm-12">
                                    <div class="input-group">
                                        <span class="input-group-prepend">
                                            <label class="input-group-text"><i class="icon-user"></i></label>
                                        </span>
                                        <asp:TextBox ID="txt_Amount" runat="server" ClientIDMode="Static"
                                            class="form-control" placeholder="Amount"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            
                
                    <div class="row">
                        <div class="col-md-12 col-sm-12">
                            <div class="alert alert-success alert-dismissible mb-2" role="alert" runat="server" id="success_msg">
                                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                                <strong>Success!</strong>
                                <asp:Label ID="success_Label" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        
                    </div>
                            <div class="row">
                                <div class="col-md-12 col-sm-12">
                            <button id="btn_Save" runat="server" class="btn btn-primary btn-block"
                                onserverclick="btn_Save_ServerClick">
                                <i class="fa fa-money-bill-alt"></i> Make Payment
                            </button>
                        </div>
                            </div>
                        </div>

                    </div>
                </div>
</ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddl_IDs" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddl_Meters" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="btn_Calculate" EventName="ServerClick" />
                        <%--<asp:AsyncPostBackTrigger ControlID="btn_Save" EventName="ServerClick" />--%>
                    </Triggers>
                </asp:UpdatePanel>
        </div>
        <div class="table-responsive">
            <asp:Repeater ID="repeat" runat="server">
                <HeaderTemplate>
                    <table id="order-table" class="table table-hover">
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
                                <asp:LinkButton ID="edit" runat="server"
                                    CssClass="btn btn-outline-info btn-sm"> 
                                            <span class="fa fa-edit"></span> </asp:LinkButton>
                                <asp:LinkButton ID="delete" runat="server"
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
</asp:Content>
