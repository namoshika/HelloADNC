<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Frameset//EN">
<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
	<meta http-equiv="X-UA-Compatible" content="IE=100">
	<title>商品注文画面 v00</title>
	<style type="text/css">
		h1{
			font-size: 1.3em;
			text-align: center;
			margin: 0px;
		}
		.orderparam{
			margin: 1em 0em;
		}
		.orderparam > h2{
			font-size: 1em;
			font-weight: normal;
			margin: 0px;
		}
		.orderparam > p{
			margin: 0px;
		}
		.listup{
			margin: 0px;
			padding: 0px;
		}
		.listup > li{
			list-style: none;
		}
		.hori > li{
			float: left;
		}
		.hori:after {
			content: "";
			clear: both;
			width: 0px;
			display: block;
			visibility: hidden;
		}
	</style>
</head>
<body>
	<h1>商品注文画面</h1>
	<p>現在、以下の入力内容となっております。お間違いないでしょうか</p>
	<div class="orderparam">
		<h2>商品</h2>
		<p>
		<?php
			switch($_POST["item"]){
				case 0:
					echo "PHP入門(1000円)";
					break;
				case 1:
					echo "PHP入門の入門(1000円)";
					break;
				case 2:
					echo "PHP入門の入門の入門(1000円)";
					break;
				case 3:
					echo "PHP入門の入門の入門の入門(1000円)";
					break;
			}
		?>
		</p>
	</div>
	<div class="orderparam">
		<h2>お名前</h2>
		<p><?php echo $_POST["namae"]; ?></p>
	</div>
	<div class="orderparam">
		<h2>送付先</h2>
		<p><?php echo $_POST["itemtarget"]; ?></p>
	</div>
	<div class="orderparam">
		<h2>配送の希望時間</h2>
		<?php
			switch($_POST["hopetime"]){
				case 0:
					echo "午前";
					break;
				case 1:
					echo "午後";
					break;
				case 2:
					echo "夜間";
					break;
			}
		?>
	</div>
	<div class="orderparam">
		<h2>オプション</h2>
		<ul class="listup">
			<?php
				if($_POST["options"] != null){
					foreach($_POST["options"] as $key => $val){
						switch ($val){
							case "forpresent":
								echo "贈り物用包装希望";
								break;
						}
					}
				}else{
					echo "無し";
				}
			?>
		</ul>
	</div>
	<div class="orderparam">
		<h2>他のご希望</h2>
		<p><?php echo $_POST["comment"]; ?></p>
	</div>
</form>
</body>
</html>