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

	<p>
		これまでアンケートに答えたのは<?php echo $_SESSION["total_cnt"]; ?>人です。そのうち<br />
		<?php
			$mal = $_SESSION["male"];
			$fem = $_SESSION["female"];
		?>
		男性：<?php echo $mal ?>人<?php echo $mal / ($mal + $fem)*100; ?>%<br />
		女性：<?php echo $fem ?>人<?php echo $fem / ($mal + $fem)*100; ?>%<br />
	</p>
	<p>
		好きな果物は<br />
		いちご：<?php echo $_SESSION["strawberry"]; ?>人、
		みかん：<?php echo $_SESSION["orange"]; ?>人、
		すいか：<?php echo $_SESSION["watermelon"]; ?>人、
		メロン：<?php echo $_SESSION["melon"]; ?>人、
		バナナ：<?php echo $_SESSION["banana"]; ?>人
	</p>
	<p>
		趣味は<br />
		<?php
			$hobbys = array("映画", "音楽", "読書", "スポーツ");
			foreach($hobbys as $idx => $val){
				echo $val.":".$_SESSION["hobby"][$idx]."人、";
			}
		?>
	</p>
	<p>
		出身の地域は<br />
		<?php
			$regions = array("北海道", "東京", "京都");
			foreach($regions as $idx => $val){
				echo $val.":".$_SESSION["region"][$idx]."人、";
			}
		?>
	</p>
	<p>
		意見:<br />
		<?php
			foreach($_SESSION["comment"] as $idx => $val){
				echo $val."<br />";
			}
		?>
	</p>
	<br /><br />
	集計を<a href="07_questionnaire_reset.php">初期化する</a><br />
	集計を<a href="09_questionnaire_save.php">ファイルに書き込む</a><br />
	集計を<a href="10_questionnaire_load.php">ファイルから読み込む</a><br />
	さらに<a href="05_questionnaire.php">入力する</a>
</body>
</html>