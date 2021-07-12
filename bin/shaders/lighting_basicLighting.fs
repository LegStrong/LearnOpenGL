#version 330

uniform vec3 color;
uniform vec3 lightColor;
uniform vec3 lightPos;
uniform vec3 viewPos;

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

    float specularStrength = 0.5;
    vec3 viewDir = normalize(viewPos - outPos);
    vec3 reflectDir = reflect(-lightDir, norm);

    float spec = pow(max(dot(viewDir, reflectDir), 0), 32);
    vec3 specular = specularStrength * spec * lightColor;
    

    outColor = vec4(specular+ ambient + diffuse, 1.0);
}