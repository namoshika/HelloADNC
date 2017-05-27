<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Frameset//EN">
<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
	<?php session_start(); ?>
	<title>簡易アンケート v.1.0</title>
</head>
<body>
	<center><font color="blue" size="5">簡易アンケート v.1.0</font></center>
	<br /><br />
	<?php
		$_SESSION["male"] = 0;
		$_SESSION["female"] = 0;
		$_SESSION["region"] = array(0, 0, 0);
		$_SESSION["comment"] = array();
		$_SESSION["total_cnt"] = 0;
		$favNames = array("strawberry", "orange", "watermelon", "melon", "banana");
		foreach($favNames as $key => $val){
			$_SESSION[$val] = 0;
		}
		for($i = 0; $i < 4; $i++){
			$_SESSION["hobby"][$i] = 0;
		}
	?>
	<br /><br />
	初期化しました。さらに<a href="05_questionnaire.php">入力する</a><br />
</body>
</html>