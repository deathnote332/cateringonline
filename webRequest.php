<?php 

$function = $_REQUEST['function'];


switch($function){
	case 'deleteData';
        deleteData();
        break;

   case 'getReservation';
        getReservation();
        break;

	case 'saveEvent';
		saveEvent();
		break;
	break;
	case 'updateEvent';
		updateEvent();
		break;
	break;
	
	case 'getEvent';
		getEvent();
		break;
	break;

    case 'savePackage';
        savePackage();
        break;
	case 'updatePackage';
		updatePackage();
		break;

    case 'getPackage';
        getPackage();
        break;
		
	case 'saveFood';
        saveFood();
        break;
	case 'updateFood';
        updateFood();
        break;
    case 'getFood';
        getFood();
        break;
	case 'getFoodType';
        getFoodType();
        break;


		
	case 'saveMenu';
        saveMenu();
        break;
    case 'getMenu';
        getMenu();
        break;
		
	case 'addFoodMenu';
		 addFoodMenu();
		 break;
		 
		 
	case 'getEventimage';
		 getEventimage();
		 break;

	
	case 'saveReservation';
		 saveReservation();
		 break;
		 
	case 'getPackageFromEvent';
		 getPackageFromEvent();
		 break;
		 
	case 'getFoodFromEventPackage';
		 getFoodFromEventPackage();
		 break;

	case 'login';
		login();
		break;


}


function getReservation(){
	$con = mysqli_connect("localhost","root","","catering");
	$str ="select reservations.*, event_name,package_name from reservations inner join events on events.id = event_id inner join packages on packages.id = package_id";
	$data = mysqli_query($con,$str);
	$getData= array();
	while($row = mysqli_fetch_assoc($data)){
		$getData[] = $row;
	}

	echo json_encode($getData);
}

function deleteData(){
	$table_name = $_POST['table_name'];
	$id = $_POST['id'];

	$con = mysqli_connect("localhost","root","","catering");
	$str ="delete from ".$table_name." where id = '$id'";
	
	$delete = mysqli_query($con,$str);
	if($delete){
		echo "Deleted Successfully";
	}
}


 function saveEvent(){
	$con = mysqli_connect("localhost","root","","catering");
	$ename = $_POST['event_name'];
	$edec = $_POST['event_description'];
	$fname = $_POST['file_name'];
	$image = mysql_real_escape_string($_POST['image']);
	$strSameEvent = "select * from events where event_name = '$ename'";
	$ifSame = mysqli_query($con,$strSameEvent);
	$same = false;
	while($row = mysqli_fetch_assoc($ifSame)){
	    $same = true;
    }
    if($same){
	    $message= "Duplicate event name";
    }else{
        $str ="insert into events(event_name,event_description,file_name,image) values('$ename','$edec','$fname','$image')";
        mysqli_query($con,$str);
        $message = "Event Successfully added";
    }
    echo $message;
}

function updateEvent(){
	$con = mysqli_connect("localhost","root","","catering");
	$ename = $_POST['event_name'];
	$id = $_POST['id'];
	$edec = $_POST['event_description'];
	$fname = $_POST['file_name'];
	$image = mysql_real_escape_string($_POST['image']);
	$strSameEvent = "update events set event_name = '$ename', event_description = '$edec', file_name = '$fname',image='$image' where id='$id'";
	$updateEvent = mysqli_query($con,$strSameEvent);
	if($updateEvent){
		$message = "Event Successfully updated.";
	}
    echo $message;
}



 function getEvent(){
	$con = mysqli_connect("localhost","root","","catering");
	$str ="select * from events";
	$data = mysqli_query($con,$str);
	$getData= array();
	while($row = mysqli_fetch_assoc($data)){
		$getData[] = $row;
	}

	echo json_encode($getData);
}

function savePackage(){
    $con = mysqli_connect("localhost","root","","catering");
    $ename = $_POST['package_name'];
    $edec = $_POST['price_head'];
    $fname = $_POST['event_id'];
    $strSameEvent = "select * from packages where package_name = '$ename' and event_id = '$fname'";
    $ifSame = mysqli_query($con,$strSameEvent);
    $same = false;
    while($row = mysqli_fetch_assoc($ifSame)){
        $same = true;
    }
    if($same){
        $message= "Duplicate package";
    }else{
        $str ="insert into packages(package_name,price_head,event_id) values('$ename','$edec','$fname')";
        mysqli_query($con,$str);
        $message = "Package successfully added.";
    }
    echo $message;

}

function updatePackage(){
    $con = mysqli_connect("localhost","root","","catering");
	$id = $_POST['id'];
    $ename = $_POST['package_name'];
    $edec = $_POST['price_head'];
    $fname = $_POST['event_id'];
    $strSameEvent = "update packages set package_name = '$ename',event_id = '$fname',price_head='$edec' where id='$id'";
    $updatePackage = mysqli_query($con,$strSameEvent);
    if($updatePackage){
        $message = "Package updated successfully";
    }
    echo $message;

}



function getPackage(){
    $con = mysqli_connect("localhost","root","","catering");
    $str ="select packages.*,events.event_name from packages INNER JOIN events on event_id = events.id	";
    $data = mysqli_query($con,$str);
	$getData= array();
    while($row = mysqli_fetch_assoc($data)){
        $getData[] = $row;
    }
    echo json_encode($getData);
}


function saveFood(){
    $con = mysqli_connect("localhost","root","","catering");
    $food_name = $_POST['food_name'];
    $food_description = $_POST['food_description'];
    $food_type_id = $_POST['food_type_id'];
	$file_name = $_POST['file_name'];
	$image = mysql_real_escape_string($_POST['image']);
	$strSameFood = "select * from foods where food_name = '$food_name' and food_type_id = '$food_type_id'";
    $ifSame = mysqli_query($con,$strSameFood);
    $same = false;
    while($row = mysqli_fetch_assoc($ifSame)){
        $same = true;
    }
    if($same){
        $message= "Duplicate food name";
    }else{
        $str ="insert into foods(food_name,food_description,food_type_id,file_name,image) values('$food_name','$food_description','$food_type_id','$file_name','$image')";
        mysqli_query($con,$str);
        $message = "Success";
    }
    echo $message;

}


function updateFood(){
    $con = mysqli_connect("localhost","root","","catering");
    $id = $_POST['id'];
	$food_name = $_POST['food_name'];
    $food_description = $_POST['food_description'];
    $food_type_id = $_POST['food_type_id'];
	$file_name = $_POST['file_name'];
	$image = mysql_real_escape_string($_POST['image']);
	$strFood = "update foods set food_name = '$food_name', food_description='$food_description', food_type_id='$food_type_id',file_name='$file_name',image='$image' where id='$id'";
    $ifUpdateFood = mysqli_query($con,$strFood);
    if($ifUpdateFood){
        $message = "Food successfully updated";
    }
    echo $message;

}

function getFood(){
    $con = mysqli_connect("localhost","root","","catering");
    $str ="select foods.*,food_type.food_type from foods inner join food_type on food_type.id =  food_type_id";
    $data = mysqli_query($con,$str);
	$getData= array();
    while($row = mysqli_fetch_assoc($data)){
        $getData[] = $row;
    }
    echo json_encode($getData);
}



function saveMenu(){
    $con = mysqli_connect("localhost","root","","catering");
    $menu_name = $_POST['menu_name'];
    $event_id = $_POST['event_id'];
    $package_id = $_POST['package_id'];
	$strSameFood = "select * from menus where menu_name = '$menu_name' and event_id = '$event_id' and package_id = '$package_id'";
    $ifSame = mysqli_query($con,$strSameFood);
    $same = false;
    while($row = mysqli_fetch_assoc($ifSame)){
        $same = true;
    }
    if($same){
        $message= "Duplicate menu";
    }else{
        $str ="insert into menus(menu_name,event_id,package_id) values('$menu_name','$event_id','$package_id')";
        mysqli_query($con,$str);
		
        $message = "Menu successfully added.";
    }

    echo $message;

}


function getMenu(){
    $con = mysqli_connect("localhost","root","","catering");
    $str ="select menus.*,events.event_name,packages.package_name from menus inner join events on events.id =  event_id inner join packages on packages.id = package_id";
    $data = mysqli_query($con,$str);
	$getData= array();
    while($row = mysqli_fetch_assoc($data)){
        $getData[] = $row;
    }
    echo json_encode($getData);
}

function getFoodType(){
    $con = mysqli_connect("localhost","root","","catering");
    $str ="select * from food_type";
    $data = mysqli_query($con,$str);
	$getData= array();
    while($row = mysqli_fetch_assoc($data)){
        $getData[] = $row;
    }
    echo json_encode($getData);
	
}


function addFoodMenu(){
	
	$con = mysqli_connect("localhost","root","","catering");
	$food_id = $_POST['food_id'];
	$strGet="select * from menus order by id asc";
	$getLastId = mysqli_query($con,$strGet);
	while($row = mysqli_fetch_assoc($getLastId)){
		$lastId = $row['id'];
	}
	$str ="insert into food_menu(food_id,menu_id) values('$food_id','$lastId')";
	mysqli_query($con,$str);

}


function getEventimage(){
	
	$con = mysqli_connect("localhost","root","","catering");
	$event_id = $_POST['event_id'];
	$strGet="select * from events where id='$event_id'";
	$getimage = mysqli_query($con,$strGet);
	$getData= array();
    while($row = mysqli_fetch_assoc($getimage)){
        $getData[] = $row;
    }
    echo json_encode($getData);
	
}


function saveReservation(){
	
	$con = mysqli_connect("localhost","root","","catering");
	$reservation_date = date('Y-m-d H:i:s');;
	$event_date = $_POST['event_date'];
	$edate = date('Y-m-d H:i:s', strtotime($event_date));
	$venue = $_POST['venue'];
	$last_name = $_POST['last_name'];
	$first_name = $_POST['first_name'];
	$contact = $_POST['contact'];
	$event_id = $_POST['event_id'];
	$package_id = $_POST['package_id'];
	$total_guest = $_POST['total_guest'];
	$add_ons = $_POST['add_ons'];
	
	$strCheckExistingEventDate = "select * from reservations where event_date = '$edate'"; 
	$ifSame = mysqli_query($con,$strCheckExistingEventDate);
	$same = false;
    while($row = mysqli_fetch_assoc($ifSame)){
        $same = true;
    }
    if($same){
        $message= "Existing reservation date";
    }else{
		
		$strGet="insert into reservations(reservation_date,event_date,venue,last_name,first_name,contact,event_id,package_id,total_guest,add_ons)
			values('$reservation_date','$edate','$venue','$last_name','$first_name','$contact','$event_id','$package_id','$total_guest','$add_ons')";
		mysqli_query($con,$strGet);
		$message =  "Successfully added reservation";
    }

    echo $message;

}

function getPackageFromEvent(){
	
	$con = mysqli_connect("localhost","root","","catering");
	$event_id = $_POST['event_id'];
	$strGet = "select * from packages where event_id = '$event_id'";
	
	$getPackage = mysqli_query($con,$strGet);
	$getData= array();
    while($row = mysqli_fetch_assoc($getPackage)){
        $getData[] = $row;
    }
    echo json_encode($getData);
	
	
}

function getFoodFromEventPackage(){
	
	$con = mysqli_connect("localhost","root","","catering");
	$event_id = $_POST['event_id'];
	$package_id = $_POST['package_id'];
	$menu_id = $_POST['menu_id'];
	
	if($menu_id == ""){
		$strGet = "select foods.*,food_type.food_type from menus inner join food_menu on menus.id = food_menu.menu_id 
				inner join foods on foods.id = food_menu.food_id 
				inner join food_type on foods.food_type_id = food_type.id
				where menus.event_id = '$event_id' and menus.package_id='$package_id'";
	}else{
		$strGet = "select foods.*,food_type.food_type from menus inner join food_menu on menus.id = food_menu.menu_id 
				inner join foods on foods.id = food_menu.food_id 
				inner join food_type on foods.food_type_id = food_type.id
				where menus.event_id = '$event_id' and menus.package_id='$package_id' and menus.id= '$menu_id'";
	}
	
	
	$getPackage = mysqli_query($con,$strGet);
	$getData= array();
    while($row = mysqli_fetch_assoc($getPackage)){
        $getData[] = $row;
    }
    echo json_encode($getData);
	
	
}

function getInclusions(){
	
	$con = mysqli_connect("localhost","root","","catering");
	$event_id = $_POST['event_id'];
	
	$strGet = "select event_description from events where id = '$event_id'";
	
	$getPackage = mysqli_query($con,$strGet);
	$getData= array();
    while($row = mysqli_fetch_assoc($getPackage)){
        $getData[] = $row;
    }
    echo json_encode($getData);
	
	
}


function login(){
	
	$con = mysqli_connect("localhost","root","","catering");
    $username = $_POST['username'];
    $password = $_POST['password'];
   
	$strLogin = "select * from users where username = '$username' and password = '$password'";
    $ifSame = mysqli_query($con,$strLogin);
    $same = false;
	$userType = 0;
	$data = array();
    while($row = mysqli_fetch_assoc($ifSame)){
        $same = true;
		$data[] = $row;
		
    }
    if($same){
        $message= json_encode($data);
    }else{
     
        $message = "Invalid credentials";
    }

    echo $message;
	
	
}



?>