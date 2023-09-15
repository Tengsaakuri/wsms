<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Payment-List.aspx.cs" Inherits="WSMS.Admin.Payment_List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="header" runat="server">
    <div class="row align-items-end">
        <div class="col-lg-8">
            <div class="page-header-title">
                <i class="feather icon-user-plus bg-c-blue"></i>
                <div class="d-inline">
                    <h5>Payments List</h5>
                    <span>List of all payments</span>
                </div>
            </div>
        </div>
        <div class="col-lg-4">
            <div class="page-header-breadcrumb">
                <ul class=" breadcrumb breadcrumb-title">
                    <li class="breadcrumb-item">
                        <a href="dashboard.aspx"><i class="icon-home"></i></a>
                    </li>
                    <li class="breadcrumb-item"><a href="#!">Payments</a>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <div class="card">
                <div class="card-header">
                    <h5>Payments List</h5>
                </div>
                <div class="card-body">
                    <div class="row">                   
                        <div class="col-md-4 col-sm-12">
                            <div class="form-group">
                                <asp:TextBox ID="TextBox1" runat="server" ClientIDMode="Static"
                                    class="form-control" placeholder="By Customer..."></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4 col-sm-12">
                            <div class="form-group">
                                <asp:TextBox ID="txt_Meter" runat="server" ClientIDMode="Static"
                                    class="form-control" placeholder="By Meter..."></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4 col-sm-12">
                            <div class="form-group">
                                <asp:TextBox ID="txt_Period" runat="server" ClientIDMode="Static"
                                    class="form-control" placeholder="By Period..."></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <hr />
                    <div class="table-responsive">
                        <asp:Repeater ID="repeat" runat="server">
                            <HeaderTemplate>
                                <table id="order-table" class="table table-hover">
                                    <thead class="text-uppercase">
                                        <tr>
                                            <th scope="col">Receipt # </th>
                                            <th scope="col">Customer </th>
                                            <th scope="col">Amount Paid</th>
                                            <th scope="col">Bill Month</th>
                                            <th scope="col">Date</th>
                                            <th scope="col">Details</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                    <asp:Label ID="Id_Label" runat="server" Text='<%#Eval("Receipt_Number") %>'></asp:Label></td>
                                    <td><%#Eval("Fullname") %></td>
                                    <td><%#Eval("AmountPaid") %></td>
                                    <td><%#Eval("BillMonth") %></td>
                                    <td><%#Eval("_Date") %></td>
                                    <td>
                                        <div class="btn-group" role="group" aria-label="Basic mixed styles example">
                                            <button ID="btn_Details" runat="server" onserverclick="btn_Details_ServerClick"
                                                 class="btn btn-outline-info btn-sm">
                                            <span class="fa fa-eye"></span> </button>
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
