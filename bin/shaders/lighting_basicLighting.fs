#version 330

uniform vec3 color;
uniform vec3 lightColor;
uniform vec3 lightPos;

in vec3 outNormal;
in vec3 outPos;

out vec4 outColor;

void main()
{
    float ambientStrength = 0.1;
    vec3 ambient = ambientStrength *lightColor;

    vec3 norm = normalize(outNormal);
    vec3 lightDir = normalize(lightPos - outPos);
    float diff = max(dot(norm, lightDir), 0.0);
    vec3 diffuse = diff * lightColor;

    outColor = vec4(diffuse + ambient, 1.0);
}