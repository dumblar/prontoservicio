#!/bin/sh

set -e
LOGFILE=/var/log/gunicorn/hello.log
LOGDIR=/var/log/gunicorn/
NUM_WORKERS=1
TIME_OUT=3600
# user/group to run as
USER=root
GROUP=root

echo "Running server with user: ${USER} (${GROUP}) int timeout ${TIME_OUT}"

cd /srv/www/app/
test -d $LOGDIR || mkdir -p $LOGDIR
exec gunicorn -b 0.0.0.0:8000 admin.wsgi:application -w $NUM_WORKERS -t $TIME_OUT
    --user=$USER --group=$GROUP --log-level=debug -
    --log-file=$LOGFILE
