<?php
class UserInfo
{
	public function __construct($name, $password, $subjects){
		$this->name = $name;
		$this->password = $password;
		$this->subjects = $subjects;
	}
	public $name;
	public $password;
	public $subjects;
}
class TaskList{
	public function __construct($tasks, $baseDate)
	{
		$this->taskWeekLists = array();
		$weekArray = $this->getDivedWeekTasks($tasks, $baseDate);
		foreach ($weekArray as $keyVal => $tskInWeek){
			//先週の予定は消す
			if($keyVal < 0)
				continue;

			//今週と来週とそれ以降の3つに予定を分けて管理する
			switch($keyVal){
				case 0:
				case 1:
					$this->taskWeekLists[$keyVal] = new TaskWeekList($keyVal, $tskInWeek);
					break;
				default:
					if(isset($this->taskWeekLists[2]) == false){
						$this->taskWeekLists[2] = new TaskWeekList(2, $tskInWeek);
					}else{
						$this->taskWeekLists[2]->taskInfos = array_merge($this->taskWeekLists[2]->taskInfos, $tskInWeek);
					}
					break;
			}
		}
	}
	public $taskWeekLists;

	private function getDivedWeekTasks($tasks, $baseDate)
	{
		$baseDate = strtotime(date("Y/m/d", $baseDate));
		$cntToNxtWeek = 7 - date("w", $baseDate);
		//次週の初日(日曜)の日付を作成する
		$nxtWeekFirstDate = $baseDate + $cntToNxtWeek * 86400;
		$weekArray = array();
		foreach ($tasks as $tsk){
			//1週間ごとに連想配列で予定を小分けする
			//予定の期限日が属する週を計算し、連想配列で仕分けする
			$days = floor(($tsk->limitDate - $nxtWeekFirstDate) / 86400 / 7) + 1;
			if(isset($weekArray[$days]) == false){
				$weekArray[$days] = array();
			}
			$weekArray[$days][] = $tsk;
		}
		return $weekArray;
	}
}
class TaskWeekList{
	public function __construct($weekOffset, $taskInfos = array()){
		$this->weekOffset = $weekOffset;
		$this->taskInfos = $taskInfos;
	}
	public $weekOffset;
	public $taskInfos;
}
class TaskInfo
{
	//YY "-" MM "-" DD " " HH ":" II ":" SS
	public function __construct($id, $subjectId, $subjectName, $name, $limitDate, $priority, $status, $memo){
		$this->id = $id;
		$this->name = $name;
		$this->limitDate = strtotime($limitDate);
		$this->priority = $priority;
		$this->status = $status;
		$this->memo = $memo;
		$this->subjectId = $subjectId;
		$this->subjectName = $subjectName;
	}
	const PRIORITY_HIGH = 1;
	const PRIORITY_NORMAL = 0;
	const STATUS_NOT_YET = 0;
	const STATUS_FREEZE = 1;
	const STATUS_FINISH = 2;

	public $id;
	public $name;
	public $limitDate;
	public $priority;
	public $status;
	public $memo;
	public $subjectId;
	public $subjectName;
}
class SubjectInfo
{
	public function __construct($id, $subjectName){
		$this->id = $id;
		$this->name = $subjectName;
	}
	public $id;
	public $name;
}
?>