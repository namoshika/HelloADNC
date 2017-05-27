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
	<p>現在の統計値を保存します。</p>
	<?php
		$fhndl = fopen("serialize.txt", "w");
		$store = array(
			"male" => (int)$_SESSION["male"],
			"female" => (int)$_SESSION["female"],
			"strawberry" => (int)$_SESSION["strawberry"],
			"orange" => (int)$_SESSION["orange"],
			"watermelon" => (int)$_SESSION["watermelon"],
			"melon" => (int)$_SESSION["melon"],
			"banana" => (int)$_SESSION["banana"]
			);
		$firstItm = true;
		foreach($store as $key => $val){
			if($firstItm == false){
				fputs($fhndl, "&");
			}
			fputs($fhndl, $val);
			$firstItm = false;
		}
		fputs($fhndl, "\n");
		$firstItm = true;
		foreach($_SESSION["hobby"] as $key => $val){
			if($firstItm == false){
				fputs($fhndl, "&");
			}
			fputs($fhndl, $val);
			$firstItm = false;
		}
		fputs($fhndl, "\n");
		$firstItm = true;
		foreach($_SESSION["region"] as $key => $val){
			if($firstItm == false){
				fputs($fhndl, "&");
			}
			fputs($fhndl, $val);
			$firstItm = false;
		}
		fputs($fhndl, "\n");
		$firstItm = true;
		foreach($_SESSION["comment"] as $key => $val){
			if($firstItm == false){
				fputs($fhndl, "&");
			}
			fputs($fhndl, $val);
			$firstItm = false;
		}
		fclose($fhndl);
	?>
	<br /><br />
	集計を<a href="07_questionnaire_reset.php">初期化する</a><br />
	さらに<a href="05_questionnaire.php">入力する</a>
</body>
</html>