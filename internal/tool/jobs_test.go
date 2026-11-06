package tool

import (
	"os"
	"path/filepath"
	"testing"

	"github.com/stretchr/testify/assert"
)

func TestCgroupJobs(t *testing.T) {
	write := func(content string) string {
		p := filepath.Join(t.TempDir(), "cpu.max")
		assert.NoError(t, os.WriteFile(p, []byte(content), 0o600))
		return p
	}

	jobs, ok := cgroupJobs(write("200000 100000\n"))
	assert.True(t, ok)
	assert.Equal(t, 2, jobs)

	jobs, ok = cgroupJobs(write("150000 100000\n"))
	assert.True(t, ok)
	assert.Equal(t, 2, jobs)

	jobs, ok = cgroupJobs(write("50000 100000\n"))
	assert.True(t, ok)
	assert.Equal(t, 1, jobs)

	_, ok = cgroupJobs(write("max 100000\n"))
	assert.False(t, ok)

	_, ok = cgroupJobs(filepath.Join(t.TempDir(), "missing"))
	assert.False(t, ok)
}

func TestOpengrepJobsEnvOverride(t *testing.T) {
	t.Setenv(jobsEnvVar, "3")
	assert.Equal(t, 3, opengrepJobs())

	t.Setenv(jobsEnvVar, "bogus")
	assert.GreaterOrEqual(t, opengrepJobs(), 1)
}
