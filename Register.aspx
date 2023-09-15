<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WSMS.Register" %>


<!DOCTYPE html>
<html lang="en">

<!-- Mirrored from demo.dashboardpack.com/admindek-html/default/auth-sign-up-social.html by HTTrack Website Copier/3.x [XR&CO'2014], Sun, 27 Nov 2022 22:44:48 GMT -->
<head>
    <title>Register</title>

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimal-ui">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />

    <link rel="icon" href="files/assets/images/favicon.ico" type="image/x-icon">

    <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,400,600,700,800" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css?family=Quicksand:500,700" rel="stylesheet">

    <link rel="stylesheet" type="text/css" href="files/bower_components/bootstrap/css/bootstrap.min.css">

    <link rel="stylesheet" href="files/assets/pages/waves/css/waves.min.css" type="text/css" media="all">
    <link rel="stylesheet" type="text/css" href="files/assets/icon/feather/css/feather.css">

    <link rel="stylesheet" type="text/css" href="files/assets/icon/themify-icons/themify-icons.css">

    <link rel="stylesheet" type="text/css" href="files/assets/icon/icofont/css/icofont.css">

    <link rel="stylesheet" type="text/css" href="files/assets/icon/font-awesome/css/font-awesome.min.css">

    <link rel="stylesheet" type="text/css" href="files/assets/css/style.css">
    <link rel="stylesheet" type="text/css" href="files/assets/css/pages.css">
</head>
<body style="background-image: url(files/assets/images/Payment.jpg); background-size: cover; background-position: center">

    <section class="login-block">

        <div class="container-fluid">
            <div class="row">
                <div class="col-sm-12">

                    <form class="md-float-material form-material" runat="server">
                        <div class="text-center">
                            <h4 class="text-light">PAYMENT SYSTEM</h4>
                        </div>
                        <div class="auth-box card">
                            <div class="card-block">
                                <div class="row m-b-20">
                                    <div class="col-md-12">
                                        <h3 class="text-center txt-primary">Sign up</h3>
                                    </div>
                                </div>
                                <div class="form-group form-primary">
                                    <asp:TextBox ID="txt_Username" runat="server" class="form-control" required=""></asp:TextBox>
                                    <span class="form-bar"></span>
                                    <label class="float-label">Choose Username</label>
                                </div>
                                <div class="form-group form-primary">
                                    <asp:TextBox ID="First_Name" runat="server" class="form-control" required=""></asp:TextBox>
                                    <span class="form-bar"></span>
                                    <label class="float-label">First Name</label>
                                </div>
                                <div class="form-group form-primary">
                                    <asp:TextBox ID="Last_Name" runat="server" class="form-control" required=""></asp:TextBox>
                                    <span class="form-bar"></span>
                                    <label class="float-label">Last Name</label>
                                </div>
                                <div class="form-group form-primary">
                                    <asp:DropDownList ID="ddl_Gender" runat="server" CssClass="form-control">
                                        <asp:ListItem>- Select gender -</asp:ListItem>
                                        <asp:ListItem>Male</asp:ListItem>
                                        <asp:ListItem>Female</asp:ListItem>
                                    </asp:DropDownList>
                                    <span class="form-bar"></span>
                                </div>
                                <div class="form-group form-primary">
                                    <asp:TextBox ID="txt_Phone" runat="server" class="form-control" required=""></asp:TextBox>
                                    <span class="form-bar"></span>
                                    <label class="float-label">Phone number</label>
                                </div>
                                <div class="form-group form-primary">
                                    <asp:TextBox ID="txt_Email" runat="server" class="form-control" required="" TextMode="Email"></asp:TextBox>
                                    <span class="form-bar"></span>
                                    <label class="float-label">Email</label>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <div class="form-group form-primary">
                                            <asp:TextBox ID="txt_Password" runat="server" class="form-control" TextMode="Password" required=""></asp:TextBox>
                                            <span class="form-bar"></span>
                                            <label class="float-label">Password</label>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <div class="form-group form-primary">
                                            <asp:TextBox ID="txt_Confirm" runat="server" class="form-control" TextMode="Password" required=""></asp:TextBox>
                                            <span class="form-bar"></span>
                                            <label class="float-label">Confirm Password</label>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12 col-sm-12">
                                        <div class="alert alert-success background-success" role="alert" runat="server" id="success_msg">                                            
                                                <a href="index.aspx">
                                            <button type="button" class="close">
                                    <span aria-hidden="true"><span class="fa fa-sign-in text-success"></span></span> 
                                </button></a>
                                            <strong>Success!</strong>
                                            <asp:Label ID="success_Label" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12 col-sm-12">
                            <div class="alert alert-danger background-danger" role="alert" runat="server" id="error_msg">
                                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                    <span aria-hidden="true" class="text-danger">&times;</span>
                                </button>
                                <strong>Stop!</strong>
                                <asp:Label ID="error_Label" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                                </div>
                                <div class="row m-t-30">
                                    <div class="col-md-12">
                                        <button class="btn btn-primary btn-md btn-block waves-effect text-center m-b-20"
                                            id="btn_Register" runat="server" onserverclick="btn_Register_ServerClick">
                                            Sign up now</button>
                                    </div>
                                </div>
                                <hr />
                                <div class="row">
                                    <div class="col-md-9">
                                        <p class="text-inverse text-left"><a href="index.aspx"><b>Back to Login</b></a></p>
                                    </div>
                                    <div class="col-md-3">
                                        <img src="files/assets/images/New-Logo.png" class="img-70" alt="small-logo.png">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </form>

                </div>

            </div>

        </div>

    </section>

    <script type="text/javascript" src="files/bower_components/jquery/js/jquery.min.js"></script>
    <script type="text/javascript" src="files/bower_components/jquery-ui/js/jquery-ui.min.js"></script>
    <script type="text/javascript" src="files/bower_components/popper.js/js/popper.min.js"></script>
    <script type="text/javascript" src="files/bower_components/bootstrap/js/bootstrap.min.js"></script>

    <script src="files/assets/pages/waves/js/waves.min.js"></script>

    <script type="text/javascript" src="files/bower_components/jquery-slimscroll/js/jquery.slimscroll.js"></script>

    <script type="text/javascript" src="files/bower_components/modernizr/js/modernizr.js"></script>
    <script type="text/javascript" src="files/bower_components/modernizr/js/css-scrollbars.js"></script>

    <script type="text/javascript" src="files/bower_components/i18next/js/i18next.min.js"></script>
    <script type="text/javascript" src="files/bower_components/i18next-xhr-backend/js/i18nextXHRBackend.min.js"></script>
    <script type="text/javascript" src="files/bower_components/i18next-browser-languagedetector/js/i18nextBrowserLanguageDetector.min.js"></script>
    <script type="text/javascript" src="files/bower_components/jquery-i18next/js/jquery-i18next.min.js"></script>
    <script type="text/javascript" src="files/assets/js/common-pages.js"></script>
</body>

<!-- Mirrored from demo.dashboardpack.com/admindek-html/default/auth-sign-up-social.html by HTTrack Website Copier/3.x [XR&CO'2014], Sun, 27 Nov 2022 22:44:48 GMT -->
</html>

