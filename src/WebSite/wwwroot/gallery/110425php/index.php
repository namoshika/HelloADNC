<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Frameset//EN">
<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
	<title>成果物一覧</title>
</head>
<body>
	<?php
		class ProductGroup{
			public function __construct($nameArg){
				$this->name = $nameArg;
			}
			public $name;
			public $children = array();
		}
		class Product{
			public function __construct($pathArg){
				$this->name = basename($pathArg);
				$this->path = $pathArg;
			}
			public $name;
			public $path;
		}

		function getProductGroups($productListDirNameArg){
			$productListDirName = $productListDirNameArg;
			$productListDirHndl = opendir($productListDirName);
			$productListObj = array();

			while(($productGroupDirName = readdir($productListDirHndl)) !== false){
				if(!is_dir($productGroupDirName) || $productGroupDirName == "." || $productGroupDirName == ".."){
					continue;
				}
				$productGroup = new ProductGroup($productGroupDirName);
				$productListObj[] = $productGroup;
				$productGroupDirHndl = opendir($productListDirName."/".$productGroupDirName);
				while(($productFileName = readdir($productGroupDirHndl)) !== false){
					if(is_dir($productFileName)){
						continue;
					}
					$productFilePath = $productGroupDirName."/".$productFileName;
					$productGroup->children[] = new Product($productFilePath);
				}
				closedir($productGroupDirHndl);
			}
			closedir($productListDirHndl);

			return $productListObj;
		}

		$proGrps = getProductGroups(".");
		foreach($proGrps as $i => $proGrp){
			echo "<h2>{$proGrp->name}</h2>";
			echo "<ul>";
			foreach($proGrp->children as $j => $proObj){
				echo "<a href=\"{$proObj->path}\">{$proObj->name}</a><br />\n";
			}
			echo "</ul>";
		}
	?>
</body>
</html>