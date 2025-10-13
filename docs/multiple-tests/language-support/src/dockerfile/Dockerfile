FROM busybox


RUN git clone https://github.com/opengrep/opengrep
RUN pip3 install opengrep
RUN opengrep -f p/xss
USER swuser
# ruleid: last-user-is-root
USER root