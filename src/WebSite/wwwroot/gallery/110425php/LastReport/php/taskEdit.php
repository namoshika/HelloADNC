<?php session_start(); ?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="ja" lang="ja">
<head>
	<title>課題詳細</title>
	<?php
	require '../common/php/dataClasses.php';
	require '../common/php/headerHeader.php';

	//データベース
	mysql_connect('db2.ne.senshu-u.ac.jp', 'webprog13', 'tokushu2011');
	mysql_select_db('webprog13');
	$personid = $_SESSION["userId"];
	$subjectid = $_POST["subjectid"];
	$taskName = $_POST["taskName"];
	$priority = $_POST["priority"] == true ? TaskInfo::PRIORITY_HIGH : TaskInfo::PRIORITY_NORMAL;
	$state = $_POST["status"];
	$memo = $_POST["memo"];
	$taskid = $_POST["taskid"];
	$limitDateText = $_POST["limitDateText"];
	switch($_POST["limitDate"]){
		case "manual":
			$limitDate = date('Y-m-d',strtotime($limitDateText));
			break;
		case "1week":
			$limitDate = date("Y-m-d", time() + 86400 * 7);
			break;
		case "2week":
			$limitDate = date("Y-m-d", time() + 86400 * 14);
			break;
	}
	switch($_POST["type"]){
		case "add":
			$res = mysql_query("insert into tskmng_registtask values(0, '{$taskName}', '{$limitDate}', {$priority}, '{$memo}', {$state}, {$personid}, {$subjectid})");
			break;
		case "change":
			$res = mysql_query("update tskmng_registtask set name = '{$taskName}', limitdate = '{$limitDate}', priority = {$priority}, memo = '{$memo}', state = {$state}, personid = {$personid}, subjectid = {$subjectid} where id = {$taskid}");
			break;
		case "status":
			$res = mysql_query("update tskmng_registtask set state = {$state} where id = {$taskid}");
			break;
		case "del":
			$res = mysql_query("delete from tskmng_registtask where id = {$taskid}");
			break;
	}

	$redirectUrl = $_POST["url"];
	echo "<meta http-equiv=\"refresh\" content=\"0.5;URL={$redirectUrl}\">";
	?>

</head>
<body>
	<?php
	require '../common/php/bodyHeader.php';
	?>
	<div class="mainDiv">
		<?php
		switch($_POST["type"]){
			case "add":
				echo "<p>課題の追加が完了しました。</p>";
				break;
			case "change":
				echo "<p>課題の更新が完了しました。</p>";
				break;
			case "status":
				echo "<p>課題の進行状況の更新が完了しました。</p>";
				break;
			case "del":
				echo "<p>課題の削除が完了しました。</p>";
				break;
		}
		?>
	</div>
</body>
</html>