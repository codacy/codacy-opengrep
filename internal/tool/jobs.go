package tool

import (
	"math"
	"os"
	"runtime"
	"strconv"
	"strings"
)

// jobsEnvVar lets the deployment set opengrep's job count explicitly,
// e.g. from the pod's CPU request.
const jobsEnvVar = "OPENGREP_JOBS"

const cgroupV2CPUMax = "/sys/fs/cgroup/cpu.max"

// opengrepJobs returns the number of parallel jobs opengrep should use:
// the env var if set, else the cgroup CPU quota, else the number of CPUs.
func opengrepJobs() int {
	if jobs, err := strconv.Atoi(os.Getenv(jobsEnvVar)); err == nil && jobs > 0 {
		return jobs
	}
	if jobs, ok := cgroupJobs(cgroupV2CPUMax); ok {
		return jobs
	}
	return runtime.NumCPU()
}

// cgroupJobs parses a cgroup v2 cpu.max file ("<quota> <period>" or "max <period>").
func cgroupJobs(path string) (int, bool) {
	content, err := os.ReadFile(path)
	if err != nil {
		return 0, false
	}
	fields := strings.Fields(string(content))
	if len(fields) != 2 || fields[0] == "max" {
		return 0, false
	}
	quota, err := strconv.ParseFloat(fields[0], 64)
	if err != nil {
		return 0, false
	}
	period, err := strconv.ParseFloat(fields[1], 64)
	if err != nil || period <= 0 || quota <= 0 {
		return 0, false
	}
	return max(1, int(math.Ceil(quota/period))), true
}
