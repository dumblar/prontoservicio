# Serializers define the API representation.
from rest_framework import serializers

from .models import *


class CompanySerializer(serializers.HyperlinkedModelSerializer):

    class Meta:
        model = Company

        fields = ('id', 'name')

        read_only_fields = ('id',)

        ordering = ['-id']
