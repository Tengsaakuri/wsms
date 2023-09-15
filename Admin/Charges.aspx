<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Charges.aspx.cs" Inherits="WSMS.Admin.Charges" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
    <div class="row align-items-end">
        <div class="col-lg-8">
            <div class="page-header-title">
                <i class="feather icon-layers bg-c-blue"></i>
                <div class="d-inline">
                    <h5>Meter Charges</h5>
                    <span>Input the details of a new Meter charge</span>
                </div>
            </div>
        </div>
        <div class="col-lg-4">
            <div class="page-header-breadcrumb">
                <ul class=" breadcrumb breadcrumb-title">
                    <li class="breadcrumb-item">
                        <a href="dashboard.aspx"><i class="icon-home"></i></a>
                    </li>
                    <li class="breadcrumb-item"><a href="#!">Charges</a>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="card">
        <div class="card-header">
            <h5>Meter Charges</h5>
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
                <div class="col-md-4 col-sm-12">
                    
                    <div class="row">                   
                        <div class="col-md-12 col-sm-12">
                            <div class="input-group">
                                <span class="input-group-prepend">
                                    <label class="input-group-text"><i class="icon-paper-clip"></i></label>
                                </span>
                                <asp:Label ID="txt_Id" runat="server" ClientIDMode="Static"
                                    class="form-control" Text="ID"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-12 col-sm-12">
                            <div class="input-group">
                                <span class="input-group-prepend">
                                    <label class="input-group-text"><i class="icon-layers"></i></label>
                                </span>
                                <asp:DropDownList ID="cmb_Category" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                    <asp:ListItem>- Select Category -</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-12 col-sm-12">
                            <div class="input-group">
                                <span class="input-group-prepend">
                                    <asp:Label ID="Label1" runat="server" Text="GH₵" class="input-group-text" Font-Size="Small"></asp:Label>
                                </span>
                                <asp:TextBox ID="txt_Amount" runat="server" ClientIDMode="Static"
                                    class="form-control" placeholder="Amount"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12 col-sm-12">
                            <asp:Button ID="btn_Save" runat="server" OnClick="btn_Save_Click"
                                class="btn btn-primary btn-block" Text="Save"/>
                        </div>
                    </div>
                    <br />
                    <hr />
                </div>

                <div class="col-md-8 col-sm-12">
                    <div class="table-responsive">
                        <asp:Repeater ID="repeat" runat="server">
                            <HeaderTemplate>
                                <table id="order-table" class="table-bordered table-hover" width="100%" cellpadding="10">
                                    <thead class="text-uppercase">
                                        <tr>
                                            <th scope="col"># </th>
                                            <th scope="col">Amount</th>
                                            <th scope="col">Category</th>
                                            <th scope="col">Action</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Label ID="Id_Label" runat="server" Text='<%#Eval("Id") %>'></asp:Label></td>
                                    <td><%#Eval("Amount") %></td>
                                    <td><%#Eval("Category") %></td>
                                    <td>
                                        <div class="btn-group" role="group" aria-label="Basic mixed styles example">
                                            <asp:LinkButton ID="edit" runat="server" CssClass="btn btn-outline-info btn-sm"
                                                OnClick="edit_Click"> <span class="fa fa-edit"></span> </asp:LinkButton>
                                            <asp:LinkButton ID="delete" runat="server" OnClientClick=" return ConfirmDelete(this);"
                                               OnClick="delete_Click" CssClass="btn btn-outline-danger btn-sm"><span class="fa fa-trash-alt"></span> </asp:LinkButton>
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


