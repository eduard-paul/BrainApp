uniform vec3 Spacing;
uniform vec3 Size;
uniform sampler3D tex;

out vec3 color;

void main(void)
{
   color = vec3(gl_FragCoord[0] - 0.5, gl_FragCoord[1] - 0.5, texture(tex, vec3((gl_FragCoord[0] - 0.5) / 10, (gl_FragCoord[1] - 0.5) / 10, Size[2] / 2.0)).r);
}