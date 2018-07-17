# Serializers define the API representation.
from django.contrib.auth.models import User
from rest_framework import serializers


class UserSerializer(serializers.HyperlinkedModelSerializer):

    class Meta:
        model = User

        fields = ('id', 'url', 'username', 'email', 'is_staff', 'is_active', 'first_name', 'last_name')

        read_only_fields = ('id',)

        ordering = ['-id']
