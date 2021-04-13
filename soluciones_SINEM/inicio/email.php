<?php
$name = $_POST['form_name'];
$email = $_POST['form_email'];
$message = $_POST['form_msg'];

$to = "enriqueskw@hotmail.com";
$subject = "RIA Emails";
$body = "Name: ".$name."\nEmail: ".$email."\nMessage: ".$message;
$headers = "From: " . $email;

//send email
mail($to, $subject, $body, $headers);
?>