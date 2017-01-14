<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
	<title>課題1</title>
</head>
<body>
	<?php
		function writeqq(){
			echo "<table bordercolor=\"black\" border=\"1\">\n";
			for($x = 1; $x < 10; $x++){
				echo "<tr>\n";
				for($y = 1; $y < 10; $y++){
					echo "<td>".$x*$y."</td>\n";
				}
				echo "</tr>\n";
			}
			echo "</table>\n";
		}

		writeqq();
	?>
</body>
</html>