<?php session_start(); ?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="ja" lang="ja">
<head>
	<title>ログイン</title>
	<?php
	require '../common/php/dataClasses.php';
	require '../common/php/headerHeader.php';

	if(isset($_POST["url"])){
		$redirectUrl = $_POST["url"];
		mysql_connect('db2.ne.senshu-u.ac.jp', 'webprog13', 'tokushu2011');
		mysql_select_db('webprog13');
		switch($_GET["req"]){
			case "login":
				//ログイン情報が添付されている場合にはログイン処理を行う
				if(isset($_POST["user"]) && isset($_POST["pass"])){
					$usrId = $_POST["user"];
					$pass = $_POST["pass"];
					$res = mysql_query("select * from tskmng_person where userid='{$usrId}' && password='{$pass}'");
					if(($row = mysql_fetch_array($res)) === false){
						//Error
						$_SESSION["userId"] = null;
					}else{
						$_SESSION["userId"] = $row["id"];
					}
				}
				if($_SESSION["userId"] === null){
					echo "<meta http-equiv=\"refresh\" content=\"0.1;URL={$redirectUrl}?failed=1\">";
				}else{
					echo "<meta http-equiv=\"refresh\" content=\"0.1;URL={$redirectUrl}\">";
				}
				break;
			case "logout":
				//SESSIONのuserを消す
				$_SESSION["userId"] = null;
				echo "<meta http-equiv=\"refresh\" content=\"0.1;URL={$redirectUrl}\">";
				break;
			case "add":
				if(isset($_POST["user"]) && isset($_POST["pass"])){
					$usrId = $_POST["user"];
					$pass = $_POST["pass"];
					if(mysql_fetch_row(mysql_query("select * from tskmng_person where userid = '{$usrId}'")) === false){
						mysql_query("insert into tskmng_person values(0, '{$usrId}', '{$pass}')");
					}
				}
				echo "<meta http-equiv=\"refresh\" content=\"0.1;URL={$redirectUrl}\">";
				break;
			case "edit":
				if($_SESSION["userId"] != null){
					$usrId = $_SESSION["userId"];
					$pass = $_POST["pass"];
					mysql_query("update tskmng_person set password = '{$pass}' where id = '{$usrId}'");
					mysql_query("delete from tskmng_registsubject where personid = {$usrId}");
					foreach(explode("\n", $_POST["subjects"]) as $val){
						if($val == ""){
							continue;
						}
						$trimed = trim($val);
						if(mysql_fetch_row(mysql_query("select * from tskmng_subject where name = '{$trimed}'")) === false){
							mysql_query("insert into tskmng_subject values(0, '{$trimed}')");
						}
						$subjectid = mysql_fetch_row(mysql_query("select id from tskmng_subject where name = '{$trimed}'"));
						$subjectid = $subjectid[0];
echo $subjectid;
						if(mysql_fetch_row(mysql_query("select * from tskmng_registsubject where personid={$usrId} && subjectid = {$subjectid}")) === false){
							mysql_query("insert into tskmng_registsubject values($usrId, {$subjectid})");
						}
					}
				}
				echo "<meta http-equiv=\"refresh\" content=\"0.1;URL={$redirectUrl}\">";
				break;
			case "del":
				if($_SESSION["userId"] != null){
					$usrId = $_SESSION["userId"];
					$_SESSION["userId"] = null;
					mysql_query("delete from tskmng_registtask where personid={$usrId}");
					mysql_query("delete from tskmng_registsubject where personid={$usrId}");
					mysql_query("delete from tskmng_person where id={$usrId}");
					echo "<meta http-equiv=\"refresh\" content=\"0.1;URL={$redirectUrl}\">";
				}
				break;
		}
	}
	?>
</head>
<body>
	<?php require '../common/php/bodyHeader.php'; ?>
	<div id="authDiv" class="mainDiv">
		<?php
		switch($_GET["req"]){
			case "login":
				echo "<h2>ログイン</h2>";
				if($_SESSION["userCode"] === null){
					echo "<p>ログイン処理中</p>\n";
				}else{
					echo "<p>ログイン成功。メインページへ転送します。</p>\n";
				}
				break;
			case "logout":
				echo "<h2>ログアウト</h2>\n"
				."<p>ログアウト処理が完了しました。</p>\n";
				break;
			case "add":
				echo "<h2>アカウント作成</h2>\n"
				."<p>アカウント作成処理が完了しました。</p>\n";
				break;
			case "del":
				echo "<h2>アカウント削除</h2>\n"
				."<p>アカウント削除処理が完了しました。</p>\n";
				break;
			default:
				echo "<h2>Auth Error</h2>";
		}
		?>
	</div>
</body>
</html>
