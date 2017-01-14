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
	<p>現在の統計値を読み込む。</p>
	<?php
		$ftxt = file_get_contents("serialize.txt");
		$farys = explode("\n", $ftxt);
		$basic = explode("&", $farys[0]);
		$hobby = explode("&", $farys[1]);
		$rgion = explode("&", $farys[2]);
		$cment = explode("&", $farys[3]);

		$store = array("male", "female", "strawberry",	"orange", "watermelon",	"melon", "banana");
		foreach($store as $idx => $val){
			$_SESSION[$val] = $basic[$idx];
		}
		foreach($hobby as $idx => $val){
			$_SESSION["hobby"][$idx] = $val;
		}
		foreach($rgion as $idx => $val){
			$_SESSION["region"][$idx] = $val;
		}
		$_SESSION["comment"] = array();
		foreach($cment as $idx => $val){
			$_SESSION["comment"][$idx] = $val;
		}

		echo "SESSION 変数表示<br />";
		print_r($_SESSION);
	?>
	<br /><br />
	集計を<a href="07_questionnaire_reset.php">初期化する</a><br />
	さらに<a href="05_questionnaire.php">入力する</a>
</body>
</html>