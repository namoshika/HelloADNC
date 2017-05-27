<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Frameset//EN">
<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
	<meta http-equiv="X-UA-Compatible" content="IE=100">
	<title>住所録修正</title>
</head>
<body>
	<?php
		extract($_POST);
		extract($_GET);

		$url = "db2.ne.senshu-u.ac.jp";
		$user = "webprog13";
		$pass = "tokushu2011";
		$db = "webprog13";

		mysql_connect($url, $user, $pass) or die("データベースの接続に失敗しました");
		mysql_select_db($db) or die("データベースの選択に失敗しました");

		if($nam != ""){
			$sql = "update jushoroku set "
				."tourokubi='{$tou}',simei='{$nam}',yubin1='{$yu1}',yubin2='{$yu2}',"
				."jusho1='{$ju1}',jusho2='{$ju2}',denwa='{$tel}',fax='{$fax}',keitai='{$kei}',"
				."meruado='{$mai}',biko='{$bik}'\n"
				."where renban={$ren}";
			echo $sql."<br />";
			mysql_query($sql);
			echo "レコードの修正が完了しました";

			exit;
		}

		$sql = "select * from jushoroku where renban={$id}";
		$result = mysql_query($sql);
		$row = mysql_num_rows($result);
		if ($row == 0){
			echo "<p>該当データがありません。</p>";
		}else{
			while ($row = mysql_fetch_array($result)){
				echo "<p>データを修正してください。</p>";
				echo "<form action=\"{$_SERVER["PHP_SELF"]}\" method=\"post\">";
				echo "<p>連番：{$row["renban"]}</p>";
				echo "<p>登録日：{$row["tourokubi"]}</p>";
				echo "<p>氏名：<input type=\"text\" name=\"nam\" value=\"{$row["simei"]}\" size=\"40\" /></p>";
				echo "<p>郵便番号：<input type=\"text\" name=\"yu1\" value=\"{$row["yubin1"]}\" size=\"5\" />-<input type=\"text\" name=\"yu2\" value=\"{$row["yubin2"]}\" size=\"5\" /></p>";
				echo "<p>住所1：<input type=\"text\" name=\"ju1\" value=\"{$row["jusho1"]}\" size=\"50\" /></p>";
				echo "<p>住所2：<input type=\"text\" name=\"ju2\" value=\"{$row["jusho2"]}\" size=\"50\" /></p>";
				echo "<p>TEL：<input type=\"text\" name=\"tel\" value=\"{$row["denwa"]}\" size=\"20\" /></p>";
				echo "<p>FAX：<input type=\"text\" name=\"fax\" value=\"{$row["fax"]}\" size=\"20\" /></p>";
				echo "<p>ケータイ：<input type=\"text\" name=\"kei\" value=\"{$row["keitai"]}\" size=\"20\" /></p>";
				echo "<p>MAIL：<input type=\"text\" name=\"mai\" value=\"{$row["meruado"]}\" size=\"25\" /></p>";
				echo "<p>備考：<textarea type=\"text\" name=\"bik\" row=\"10\" col=\"50\">{$row["biko"]}</textarea></p>";

				echo "<input type=\"hidden\" name=\"tou\" value=\"{$row["tourokubi"]}\" />";
				echo "<input type=\"hidden\" name=\"ren\" value=\"{$row["renban"]}\" />";

				echo "<p><input type=\"submit\" value=\"登録\">";
				echo "<p><input type=\"reset\" value=\"リセット\">";
				echo "</form>";
			}
		}
	?>
</body>
</html>