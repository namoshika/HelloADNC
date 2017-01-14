<?php
session_start();
if($_SESSION["userId"] === null){
	include 'php/authForm.php';
}else{
	include 'php/taskList.php';
}
?>