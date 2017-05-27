<?php session_start(); ?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="ja" lang="ja">
<head>
	<title>課題詳細</title>
	<?php
	require 'common/php/dataClasses.php';
	require 'common/php/headerHeader.php';
	?>
</head>
<body>
	<?php
	require 'common/php/bodyHeader.php';
	?>
	<div id="authDiv" class="mainDiv">
		<h2>ログイン</h2>
		<form method="post" action="php/authenticate.php?req=login">
			<?php
			if($_GET["failed"]){
				echo "<p class=\"notice\">ログインに失敗しました。ユーザID・パスワードに間違いが無いか確認してください。</p>";
			}
			?>
			<p>ログイン情報を入力してください。</p>
			<dl class="keyValDef">
			<dt class="key">ユーザID</dt>
			<dd class="val"><input name="user" type="text" /></dd>
			<dt class="key">パスワード</dt>
			<dd class="val"><input name="pass" type="password" /></dd>
			</dl>
			<input type="hidden" name="url" value="../" />
			<input type="submit" value="ログイン" />
			<input type="reset" value="クリア" />
		</form>
	</div>
</body>
</html>