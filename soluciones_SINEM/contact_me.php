if(isset($_POST['name'],$_POST['email'],$_POST['message'])){
    $name = $_POST['name'];
    $email = $_POST['email'];
    $message = $_POST['message']; 

    echo $name; // then echo $email and then $message
}