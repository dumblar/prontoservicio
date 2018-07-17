from django.contrib.auth.models import User
from django.views.decorators.csrf import csrf_exempt
from rest_framework import viewsets
from rest_framework.decorators import permission_classes
from rest_framework.permissions import DjangoModelPermissions
from rest_framework.response import Response
from .serializers import UserSerializer


# ViewSets define the view behavior.
@permission_classes((DjangoModelPermissions, ))
class UserViewSet(viewsets.ModelViewSet):
    queryset = User.objects.all()
    serializer_class = UserSerializer

    def list(self, request, *args, **kwargs):

        if not request.user.is_superuser:
            queryset = User.objects.filter(is_superuser=False)
        else:
            queryset = User.objects.all()

        serializer_context = {
            'request': request,
        }

        serialized = UserSerializer(queryset, many=True, context=serializer_context)

        return Response(serialized.data)
