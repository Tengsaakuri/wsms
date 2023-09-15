<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="WSMS.Admin.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
    <div class="row align-items-end">
        <div class="col-lg-8">
            <div class="page-header-title">
                <i class="icon-home bg-c-blue"></i>
                <div class="d-inline">
                    <h5>Dashboard</h5>
                    <span>Summary of all tranctions, activiyies</span>
                </div>
            </div>
        </div>
        <div class="col-lg-4">
            <div class="page-header-breadcrumb">
                <ul class=" breadcrumb breadcrumb-title">
                    <li class="breadcrumb-item">
                        <a href="#"><i class="icon-home"></i></a>
                    </li>
                    <li class="breadcrumb-item"><a href="#!">Dashboard</a> </li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="row">

        <div class="col-xl-3 col-md-6">
            <div class="card prod-p-card card-red">
                <div class="card-body">
                    <div class="row align-items-center m-b-30">
                        <div class="col">
                            <h6 class="m-b-5 text-white">Total Customers</h6>
                            <h3>
                                <asp:Label ID="Customers" runat="server" Text="Label"></asp:Label>
                            </h3>
                        </div>
                        <div class="col-auto">
                            <i class="fas fa-money-bill-alt text-c-red f-18"></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-xl-3 col-md-6">
            <div class="card prod-p-card card-blue">
                <div class="card-body">
                    <div class="row align-items-center m-b-30">
                        <div class="col">
                            <h6 class="m-b-5 text-white">Total  Meters</h6>
                            <h3>
                                <asp:Label ID="Meters" runat="server" Text="Label"></asp:Label>
                            </h3>
                        </div>
                        <div class="col-auto">
                            <i class="fas fa-database text-c-blue f-18"></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-xl-3 col-md-6">
            <div class="card prod-p-card card-green">
                <div class="card-body">
                    <div class="row align-items-center m-b-30">
                        <div class="col">
                            <h6 class="m-b-5 text-white">Total  Users</h6>
                            <h3>
                                <asp:Label ID="Users" runat="server" Text="Label"></asp:Label>
                            </h3>
                        </div>
                        <div class="col-auto">
                            <i class="fas fa-user-md text-c-green f-18"></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-xl-3 col-md-6">
            <div class="card prod-p-card card-yellow">
                <div class="card-body">
                    <div class="row align-items-center m-b-30">
                        <div class="col">
                            <h6 class="m-b-5 text-white">Total Consumption</h6>
                            <h3>
                                <asp:Label ID="Consumption" runat="server" Text="Label"></asp:Label>
                            </h3>
                        </div>
                        <div class="col-auto">
                            <i class="fas fa-dollar-sign text-c-yellow f-18"></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="card-body">
          
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
                                    <button id="btn_Details" runat="server"
                                        class="btn btn-outline-info btn-sm">
                                        <span class="fa fa-eye"></span>
                                    </button>
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
