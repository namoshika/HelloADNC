<?php session_start(); ?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="ja" lang="ja">
<head>
	<title>アカウントの作成・編集</title>
	<?php
	include 'common/php/dataClasses.php';
	include 'common/php/headerHeader.php';

	mysql_connect('db2.ne.senshu-u.ac.jp', 'webprog13', 'tokushu2011');
	mysql_select_db('webprog13');

	if(isset($_SESSION["userId"])){
		$id = $_SESSION["userId"];
		$res = mysql_query("select userid, password from tskmng_person where id={$id}");
		if(!($row = mysql_fetch_array($res))){
			die("Error");
		}else{
			$usrName = $row["userid"];
			$usrPass = $row["password"];

			$registSubjects = array();
			$res = mysql_query("select B.name from tskmng_registsubject as A inner join tskmng_subject as B on A.subjectid = B.id where A.personid={$id}");
			while($row = mysql_fetch_array($res)){
				$registSubjects[] = $row["name"];
			}
			$usrInfo = new UserInfo($usrName, $usrPass, $registSubjects);
		}
	}else{
		$usrInfo = null;
	}
	?>
	<style type="text/css">
	dl.keyValDef>.key {
		width: 10em;
	}
	</style>
</head>
<body>
	<?php include 'common/php/bodyHeader.php'; ?>
	<div class="mainDiv">
		<div id="taskQuickEditDiv">
			<h2>操作</h2>
			<p>このページから...</p>
			<ul>
				<li><a href="."><?php echo isset($_SESSION["userId"]) ? "課題リストへ戻る" : "ログイン画面へ戻る"; ?></a></li>
			</ul>
			<p>アカウントを...</p>
			<ul>
				<li><a href="javascript:(function(){document.forms.formA.submit();})();">入力内容で<?php echo isset($_SESSION["userId"]) ? "更新" : "登録"; ?>する</a></li>
				<?php
				if(isset($_SESSION["userId"]) == true){
					echo "<li><a href=\"javascript:(function(){document.forms.formB.submit();})();\">削除する</a></li>";
				}
				?>
			</ul>
		</div>
		<div id="taskDetailDiv">
			<h2><?php echo isset($_SESSION["userId"]) ? "アカウント情報の編集" : "アカウント情報の登録";?></h2>
			<form name="formA" method="post" action="php/authenticate.php<?php echo isset($_SESSION["userId"]) ? "?req=edit" : "?req=add"  ?>">
				<?php
				if($_GET["failed"]){
					echo "<p class=\"notice\">アカウントの作成・更新に失敗しました。ユーザID・パスワードに間違いが無いか確認してください。</p>";
				}
				?>
				<p>ログイン情報を入力してください。</p>
				<dl class="keyValDef">
				<dt class="key">ユーザID</dt>
				<dd class="val"><?php echo $usrInfo == null ? "<input name=\"user\" type=\"text\" />" : $usrInfo->name; ?></dd>
				<dt class="key">パスワード</dt>
				<dd class="val"><input name="pass" type="password" value="<?php echo $usrInfo->password; ?>" /></dd>
				<?php if(isset($_SESSION["userId"])){ ?>
				<dt class="key">課題管理する科目名を入力。(改行を入れることで複数の科目を入力する事ができます)</dt>
				<dd class="val"><textarea name="subjects" cols="50" rows="25"><?php foreach($usrInfo->subjects as $sbNm){ echo $sbNm."\n"; } ?></textarea></dd>
				<?php } ?>
				</dl>
				<input type="hidden" name="url" value="../" />
				<!--<input type="submit" value="登録" />
				<input type="reset" value="クリア" />-->
			</form>
			<form name="formB" method="post" action="php/authenticate.php?req=del">
				<input type="hidden" name="url" value="../" />
			</form>
		</div>
	</div>
</body>
</html>
