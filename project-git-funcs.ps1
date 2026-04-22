$branchs = git branch

$a_branch

foreach ($branch in $branchs) {
	if ($branch.Contains("*")) {
		$a_branch = $branch.Trim("*").Trim()
	}
}

. git-funcs

Switch -Wildcard ($a_branch) {
	"*.dev" {
		merge "main.fix" $a_branch
		merge "main" "main.fix"
		git checkout $a_branch
	}
	"*.fix" {
		merge "main.dev" $a_branch
		merge "main" "main.dev"
		git checkout $a_branch
	}
	default {
		merge "main.dev" $a_branch
		merge "main.fix" "main.dev"
		git checkout $a_branch
	}
}

$branchs = git remote

foreach ($branch in $branchs) {
	push-all $branch $True
}