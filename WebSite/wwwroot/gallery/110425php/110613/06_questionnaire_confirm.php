<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Frameset//EN">
<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
	<?php
		session_start();
	?>
	<title>questionnaire_confirm.php</title>
</head>
<body>
	<center><font color="blue" size="5">簡易アンケート v.1.0</font></center>
	<br /><br />
	<?php
		echo "POST 変数表示<br />";
		foreach($_POST as $index => $value){
			echo "$index:$value<br />";
		}
		echo "<br />";

		$_SESSION["male"] += $_POST["gender"] == 0 ? 1 : 0;
		$_SESSION["female"] += $_POST["gender"] != 0 ? 1 : 0;

		$favNames = array("strawberry", "orange", "watermelon", "melon", "banana");
		foreach($favNames as $key => $val){
			if($_SESSION[$val] == null){
				$_SESSION[$val] = 0;
			}
			if($_POST[$val] == 1){
				$_SESSION[$val]++;
			}
		}
		for($i = 0; $i < 4; $i++){
			if($_SESSION["hobby"][$i] == null){
				$_SESSION["hobby"][$i] = 0;
			}
			if($_POST["hobby"][$i] == 1){
				$_SESSION["hobby"][$i]++;
			}
		}
		if($_SESSION["region"] == null){
			$_SESSION["region"] = array(0, 0, 0);
		}
		$_SESSION["region"][$_POST["region"]]++;
		if($_SESSION["comment"] == null){
			$_SESSION["comment"] = array();
		}
		$_SESSION["comment"][] = $_POST["comment"];
		if($_SESSION["total_cnt"] == null){
			$_SESSION["total_cnt"] = 0;
		}
		$_SESSION["total_cnt"]++;

		echo "SESSION 変数表示<br />";
		print_r($_SESSION);
	?>
	<br /><br />
	登録しました。さらに<a href="05_questionnaire.php">入力する</a><br />
	これまでの集計結果を<a href="08_questionnaire_total.php">表示する</a>
</body>
</html>