<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="iCater.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>iCaters</title>

    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">

    <!-- Custom CSS -->
    <link href="css/landing-page.css" rel="stylesheet">

    <!-- Custom Fonts -->
    <link href="font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">
    <link href="https://fonts.googleapis.com/css?family=Lato:300,400,700,300italic,400italic,700italic" rel="stylesheet" type="text/css">

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>
    
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- Navigation -->
        <nav class="navbar navbar-default navbar-fixed-top topnav" role="navigation">
            <div class="container topnav">
                <!-- Brand and toggle get grouped for better mobile display -->
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand topnav" href="index.html">iCaters</a>
                </div>
                <!-- Collect the nav links, forms, and other content for toggling -->
                <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                    <ul class="nav navbar-nav navbar-right">
                        <li>
                            <a href="#" data-toggle="modal" data-target="#login-modal">Login</a>
                        </li>
                        <li>
                            <a href="registration.html">Registration</a>
                        </li>
                    </ul>
                </div>
                <!-- /.navbar-collapse -->
            </div>
            <!-- /.container -->
        </nav>

        <div id="registration" class="page_wrapper">
            <div class="registration_container container">
                <div id="fileForm" role="form">
                    <fieldset>
                        <legend class="text-center">Please Provide Registration Details. </legend>
                        <div class="row">
                            <div class="form-group col-sm-6">
                                <label for="txtBusienssname">Business Name<span class="req"> </span></label>
                                <input class="form-control" type="text" name="businessname" id="txtBusienssname" runat="server" required="required" />
                            </div>
                            <div class="form-group col-sm-6">
                                <label for="website">Website</label>
                                <input type="text" name="website" id="txtWebsite" class="form-control" required="required" runat="server" />
                            </div>
                        </div>

                        <div class="row">
                            <div class="form-group col-sm-6">
                                <label for="firstname">First Name<span class="req">* </span></label>
                                <input class="form-control" type="text" name="firstname" id="txtFirstName" required="required" runat="server" />
                            </div>

                            <div class="form-group col-sm-6">
                                <label for="lastname">Last Name<span class="req"> </span></label>
                                <input class="form-control" type="text" name="lastname" id="txtLastName" required="required" runat="server" />
                            </div>
                        </div>

                        <div class="row">
                            <div class="form-group col-sm-6">
                                <label for="mobilenumber">Mobile Number<span class="req"> </span></label>
                                <input type="text" name="mobilenumber" id="txtMobile" class="form-control" required="required" runat="server" />
                            </div>

                            <div class="form-group col-sm-6">
                                <label for="phonenumber">Phone Number</label>
                                <input type="text" name="phonenumber" id="txtPhone" class="form-control" required="required" runat="server" />
                            </div>
                        </div>

                        <div class="row">
                            <div class="form-group col-sm-6">
                                <label for="email">Email Address<span class="req"> </span></label>
                                <input class="form-control" type="text" name="email" id="txtEmail" required="required" runat="server" />
                            </div>

                            <div class="form-group col-sm-6">
                                <label for="fax">Fax Number</label>
                                <input type="text" name="fax" id="txtFax" class="form-control" runat="server" />
                            </div>
                        </div>

                        <div class="row">
                            <div class="form-group col-sm-6">
                                <label for="password">Password<span class="req"> </span></label>
                                <input name="password" type="password" class="form-control" id="txtPassword" data-minlength="6" required="required" runat="server" />
                            </div>

                            <div class="form-group col-sm-6">
                                <label for="password">Confirm Password<span class="req"> </span></label>
                                <input name="password" type="password" class="form-control" id="txtConfirmPassword" data-match="#txtPassword" required="required" runat="server" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-group col-sm-6">
                                <label for="state">State<span class="req"> </span></label>

                                <asp:DropDownList ID="drpState" required="required" name="state" CssClass="form-control" runat="server" OnSelectedIndexChanged="drpState_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>

                            <div class="form-group col-sm-6">
                                <label for="city">City<span class="req"> </span></label>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="drpCity" name="city" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="drpState" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-group col-sm-6">
                                <label for="area">Area<span class="req"> </span></label>
                                <input class="form-control" type="text" name="area" id="txtArea" runat="server" />
                            </div>

                            <div class="form-group col-sm-6">
                                <label for="pincode">Pincode<span class="req"> </span></label>
                                <input class="form-control" type="text" name="pincode" id="txtPincode" runat="server" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-group col-sm-6">
                                <label for="address1">Address 1<span class="req"> </span></label>
                                <input class="form-control" type="text" name="address1" id="txtAddress1" runat="server" />
                            </div>

                            <div class="form-group col-sm-6">
                                <label for="address2">Address 2<span class="req"> </span></label>
                                <input class="form-control" type="text" name="address2" id="txtAddress2" runat="server" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-6 form-group" style="display: none">
                                <label for="address">Address</label>
                                <textarea class="form-control" rows="4"></textarea>
                            </div>
                            <div class="col-sm-6 form-group">
                                <label for="businessLogo">Upload Logo</label>
                                <asp:FileUpload ID="FileUpload1" runat="server" />
                                <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" Visible="false" />
                            </div>
                        </div>


                        <div class="form-group">
                            <input type="checkbox" name="terms" id="field_terms">
                            <label for="terms">I agree to the terms & conditions of iCaters.co.in for Registration.</label>
                        </div>

                        <div class="form-group">

                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success" Text="Register" OnClick="btnSave_Click" />
                        </div>


                    </fieldset>
                </div>
                <!-- ends register form -->
            </div>

            <!-- Login Modal -->
            <div class="modal fade" id="login-modal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
                <div class="modal-dialog">
                    <div class="loginmodal-container">
                        <h1>Login to Your Account</h1>
                        <br>
                        <form>
                            <input type="text" name="user" placeholder="Username">
                            <input type="password" name="pass" placeholder="Password">
                            <input type="submit" name="login" class="login loginmodal-submit" value="Login">
                        </form>

                        <div class="login-help">
                            <a href="#">Forgot Password?</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Footer -->
        <footer>
            <div class="container">
                <div class="row">
                    <div class="col-lg-12">
                        <ul class="list-inline">
                            <li>
                                <a href="#">Home</a>
                            </li>
                            <li class="footer-menu-divider">&sdot;</li>
                            <li>
                                <a href="#about">About Us</a>
                            </li>
                            <li class="footer-menu-divider">&sdot;</li>
                            <li>
                                <a href="#services">How It Works</a>
                            </li>
                            <li class="footer-menu-divider">&sdot;</li>
                            <li>
                                <a href="#contact">Help/Suggestion</a>
                            </li>
                            <li class="footer-menu-divider">&sdot;</li>
                            <li>
                                <a href="#contact">FAQ</a>
                            </li>
                        </ul>
                        <p class="copyright text-muted small">Copyright &copy; 2014 - iCaters Pvt Ltd. All Rights Reserved</p>
                    </div>
                </div>
            </div>
        </footer>

        <!-- jQuery -->
        <script src="js/jquery.js"></script>
        
        <!-- Bootstrap Core JavaScript -->
        <script src="js/bootstrap.min.js"></script>
        <script src="js/validator.js"></script>

        <script type="text/javascript">
            //$('#fileForm').validator();
        </script>
    </form>
</body>
</html>
