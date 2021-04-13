<?php
$_name = $_POST['name'];
$_email = $_POST['email'];
$_msg = $_POST['msg'];
$_email = $_POST['email'];


$_to = "contacto@solucionesinem.com.mx";
$_subject = "Contacto Soluciones SINEM";
$_body = "Name: ".$_name."\nEmail: ".$_email."\nMessage: ".$_msg;
$_headers = "From: " . $_email;

//send email
@mail($_to, $_subject, $_body, $_headers);
?>