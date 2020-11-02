<%@ Page Title="" Language="C#" MasterPageFile="~/Index.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<div style="overflow-x: hidden">
    <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
        <ol class="carousel-indicators">
            <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
            <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
            <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
        </ol>
        <div class="carousel-inner">
            <div class="carousel-item active">
                <img class="d-block w-100" src="Image/carosuel01.jpg" alt="First slide">
            </div>
            <div class="carousel-item">
                <img class="d-block w-100" src="Image/carosuel04.jpg" alt="Second slide">
            </div>
        </div>
        <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="sr-only">Previous</span>
        </a>
        <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="sr-only">Next</span>
        </a>
    </div>

    <!-- Controls -->
    <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
        <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
        <span class="sr-only">Previous</span>
    </a>
    <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
        <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
        <span class="sr-only">Next</span>
    </a>
    <br />
    <br />
    <div class="text-center">
        <h2>Need a laundry service that collects your laundry from your doorstep and delivered to any location you want?</h2>
    </div>
    <div class="text-center">
        <h2>Why not choose laundrix? Laundrix provides affordable quick laundry services to your location 24/7</h2>
    </div>
    <br />
    <br />
    <div class="card-deck" style="margin: 10px">
        <div class="row">
            <div class="col-sm-6 card">
                <img class="card-img-top" src="Image/Booking.png" alt="Booking" style="padding:3px"/>
                <div class="card-body">
                    <p class="card-text" style="background-color:lightyellow; padding:10px; border-radius:6px">Book online or via our mobile apps for laundry collection</p>
                </div>
            </div>
            <div class="col-sm-6 card">
                <img class="card-img-top" src="Image/van.png" alt="Booking" style="padding:3px"/>
                <div class="card-body">
                    <p class="card-text" style="background-color:lightcyan; padding:10px; border-radius:6px">Laundry Collection and Delivery to your chosen addresses</p>
                </div>
            </div>
            <div class="col-sm-6 card">
                <img class="card-img-top" src="Image/laptop.png" alt="Booking" style="padding:3px"/>
                <div class="card-body">
                    <p class="card-text" style="background-color:lightyellow; padding:10px; border-radius:6px">Confirmation email on date/time when items are ready to be colleced and delivered</p>
                </div>
            </div>
            <div class="col-sm-6 card">
                <img class="card-img-top" src="Image/247.png" alt="Booking" style="padding:3px"/>
                <div class="card-body">
                    <p class="card-text" style="background-color: lightcyan; padding:10px; border-radius:6px">24/7 service so you can get your laundry back as soon as possible</p>
                </div>
            </div>
        </div>
    </div>
    <br/>
    <footer>
        <div class="container">
            <p>&copy; 2019 Laundrix.com &middot; <a href="Index.aspx">Home</a> &middot; <a href="About.aspx">About</a> &middot; <a href="Login.aspx">Log In</a> &middot; <a href="Index.aspx">Back to Top</a></p>
        </div>
    </footer>

</div>
</asp:Content>

