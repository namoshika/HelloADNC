<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
	<title>関数を使用する</title>
</head>
<body>
	<?php
		function funcA($code)
		{
			switch ($code){
				case 0:
					$message = "正常終了";
					break;
				default:
					$message = "エラー";
					break;
			}
			return $message;
		}
	?>
	<p>
		終了メッセージ:<?php echo funcA(rand(0,3)); ?>
	</p>
</body>
</html>