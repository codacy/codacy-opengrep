#include <stdio.h>
#include <string.h>
#include <time.h>
#include <errno.h>
#include <pwd.h>

void log_time_bad(time_t now) {
    struct tm *t = localtime(&now); // Noncompliant
    printf("%d\n", t->tm_hour);
}

void log_user_bad(uid_t uid) {
    struct passwd *pw = getpwuid(uid); // Noncompliant
    printf("%s\n", pw->pw_name);
}

void log_time_good(time_t now) {
    struct tm t;
    localtime_r(&now, &t);
    printf("%d\n", t.tm_hour);
}

void log_user_good(uid_t uid) {
    struct passwd pw;
    struct passwd *result;
    char buf[1024];
    getpwuid_r(uid, &pw, buf, sizeof(buf), &result);
    printf("%s\n", strerror(errno));
}
