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
		$_SESSION["total_cnt"] = 0;
		$_SESSION["male"] = 0;
		$_SESSION["female"] = 0;

		$_SESSION["strawberry"] = 0;
		$_SESSION["orange"] = 0;
		$_SESSION["watermelon"] = 0;
		$_SESSION["melon"] = 0;
		$_SESSION["banana"] = 0;

		for($i = 0; $i < 4; $i++){
			$_SESSION["hobby"][$i] = 0;
			$_SESSION["region"][$i] = 0;
		}

		unset($_SESSION["comment"])
	?>
	<br /><br />
	初期化しました。さらに<a href="01_questionnaire.php">入力する</a><br />
</body>
</html>